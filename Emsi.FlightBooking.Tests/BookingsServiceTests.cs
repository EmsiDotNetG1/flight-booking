using AutoFixture;
using AutoFixture.Xunit2;
using Emsi.FlightBooking.Bookings;
using Emsi.FlightBooking.Infrastructure.Abstraction;
using Emsi.FlightBooking.Infrastructure.DAO;
using Emsi.FlightBooking.Models;
using Moq;
using Xunit;

namespace Emsi.FlightBooking.Tests;

public class BookingsServiceTests : TestsBase
{
    // System Under test
    private readonly BookingsService _sut;
    
    // dependencies
    private readonly Mock<IBookingsRepository> _bookingsRepositoryMock = new ();
    private readonly Mock<IPassengersRepository> _passengersRepositoryMock = new ();
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new ();

    [Theory]
    [AutoData]
    public async Task BookFlightAsync_ShouldWork(Booking booking)
    {
        //act
        await _sut.BookFlightAsync(booking);
        
        //assert
        _bookingsRepositoryMock.Verify(m => m.AddAsync(It.IsAny<BookingDao>()), Times.Once);
        _unitOfWorkMock.Verify(m => m.CommitAsync(), Times.Once);
    }
    
    [Theory]
    [AutoData]
    public async Task CancelBookingAsync_ShouldWork(Guid bookingId, Guid passengerId, BookingDao bookingDao)
    {
        //arrange
        
        //act
        await _sut.CancelBookingAsync(bookingId, passengerId);
        
        //assert
        _bookingsRepositoryMock.Verify(m => m.AddAsync(It.IsAny<BookingDao>()), Times.Once);
        _unitOfWorkMock.Verify(m => m.CommitAsync(), Times.Once);
    }

}