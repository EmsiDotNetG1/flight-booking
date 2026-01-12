namespace Emsi.FlightBooking.Infrastructure.DAO;

public class FlightDao
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string DepartureFrom { get; set; }
    public string ArrivalTo { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    public int AvailableSeats { get; set; }
    public int BookedSeats { get; set; }
    public int Status { get; set; }
    public bool DirectFlight { get; set; }
}