using Emsi.FlightBooking.Models;

namespace Emsi.FlightBooking.Abstractions;

public interface IFlightsService
{
    Task<IReadOnlyCollection<Flight>> SearchFlightsAsync(string departureFrom, string arrivalTo, DateOnly departureDate,
        DateOnly? returnDate, bool directFlight);
}