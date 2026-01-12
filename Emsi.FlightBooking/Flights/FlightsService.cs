using Emsi.FlightBooking.Abstractions;
using Emsi.FlightBooking.Infrastructure.Abstraction;
using Emsi.FlightBooking.Models;
using MapsterMapper;

namespace Emsi.FlightBooking.Flights;

public class FlightsService : IFlightsService
{
    private readonly IFlightsRepository _repository;
    private readonly IMapper _mapper;

    public FlightsService(IFlightsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<Flight>> SearchFlightsAsync(string departureFrom, string arrivalTo, DateOnly departureDate, DateOnly? returnDate,
        bool directFlight)
    {
        var departureDateTime = departureDate.ToDateTime(TimeOnly.MinValue);
        var query = _repository.GetAll()
            .Where(f => f.DepartureFrom == departureFrom
                        && f.ArrivalTo == arrivalTo
                        && f.DepartureDate.Date == departureDateTime);

        if (directFlight)
            query = query.Where(f => f.DirectFlight);

        var flights = await query.ToAsyncEnumerable().ToListAsync();

        var departureFlights = flights.Select(f => _mapper.Map<Flight>(f)).ToList();

        if (returnDate.HasValue)
        {
            var returnFlights = await SearchFlightsAsync(arrivalTo, departureFrom, returnDate.Value, null, directFlight);
            departureFlights.AddRange(returnFlights);
        }
        return departureFlights;
    }
}