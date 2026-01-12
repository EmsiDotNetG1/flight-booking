using Emsi.FlightBooking.Abstractions;
using Emsi.FlightBooking.Exceptions;
using Emsi.FlightBooking.Infrastructure.Abstraction;
using Emsi.FlightBooking.Infrastructure.DAO;
using Emsi.FlightBooking.Models;
using MapsterMapper;

namespace Emsi.FlightBooking.Bookings;

public class BookingsService : IBookingsService
{
    private readonly IBookingsRepository _bookingsRepository;
    private readonly IPassengersRepository _passengersRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookingsService(IBookingsRepository bookingsRepository, IPassengersRepository passengersRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _bookingsRepository = bookingsRepository;
        _passengersRepository = passengersRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task BookFlightAsync(Booking booking)
    {
        var dao = _mapper.Map<BookingDao>(booking);
        dao.Id = Guid.NewGuid();
        dao.CreatedAt = DateTime.UtcNow;
        dao.Status = (int)BookingStatus.Paid;
        dao.Flight = null;
        dao.Passenger = null;
        
        await  _bookingsRepository.AddAsync(dao);
        await _unitOfWork.CommitAsync();
    }

    public async Task CancelBookingAsync(Guid bookingId, Guid passengerId)
    {
        var (dao, _) = await GetBookingDaoAsync(bookingId, passengerId);

        dao.CancelDate = DateTime.UtcNow;
        await _bookingsRepository.UpdateAsync(dao);
        await _unitOfWork.CommitAsync();
    }

    private async Task<(BookingDao, PassengerDao)> GetBookingDaoAsync(Guid bookingId, Guid passengerId)
    {
        var dao = await _bookingsRepository.GetByIdAsync(bookingId);
        var passenger = await _passengersRepository.GetByIdAsync(passengerId);
        if(dao == null)
            throw new FunctionalException(ExceptionTypeEnum.NotFound, $"Booking#{bookingId} not found");
        if(passenger == null)
            throw new FunctionalException(ExceptionTypeEnum.NotFound, $"Passenger#{passengerId} not found");
        if(dao.PassengerId != passengerId)
            throw new FunctionalException(ExceptionTypeEnum.BadInput, $"Passenger#{passengerId} don't have such booking#{bookingId}");
        return (dao, passenger);
    }

    public async Task ConfirmBookingAsync(Guid bookingId, Guid passengerId, string passportNumber)
    {
        var (dao, passenger) = await GetBookingDaoAsync(bookingId, passengerId);
        dao.CheckinDate = DateTime.UtcNow;
        
        passenger.Passport = passportNumber;
        await _bookingsRepository.UpdateAsync(dao);
        await _passengersRepository.UpdateAsync(passenger);
        await _unitOfWork.CommitAsync();
    }
}