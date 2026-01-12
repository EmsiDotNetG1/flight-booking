namespace Emsi.FlightBooking.Models;

public class Booking
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid FlightId { get; set; }
    public Guid PassengerId { get; set; }
    public BookingStatus Status { get; set; }
    public DateTime CheckinDate { get; set; }
    public Passenger Passenger { get; set; }
    public Flight Flight { get; set; }
    public DateTime? CancelDate { get; set; }
}