using Emsi.FlightBooking.Models;

namespace Emsi.FlightBooking.Abstractions;

public interface IBookingsService
{
    Task BookFlightAsync(Booking booking);
    Task CancelBookingAsync(Guid bookingId, Guid passengerId);
    Task ConfirmBookingAsync(Guid bookingId, Guid passengerId, string passportNumber);
}