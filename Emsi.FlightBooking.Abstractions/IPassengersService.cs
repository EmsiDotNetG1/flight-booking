using Emsi.FlightBooking.Models;

namespace Emsi.FlightBooking.Abstractions;

public interface IPassengersService
{
    Task CreatePassengerAsync(Passenger passenger);
}