namespace Emsi.FlightBooking.Infrastructure.DAO;

public class BookingDao
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid FlightId { get; set; }
    public Guid PassengerId { get; set; }
    public int Status { get; set; }
    public DateTime CheckinDate { get; set; }
    public PassengerDao Passenger { get; set; }
    public FlightDao Flight { get; set; }
    public DateTime? CancelDate { get; set; }
}