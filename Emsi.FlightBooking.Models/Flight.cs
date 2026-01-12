namespace Emsi.FlightBooking.Models;

public class Flight
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string DepartureFrom { get; set; }
    public string ArrivalTo { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    public int AvailableSeats { get; set; }
    public int BookedSeats { get; set; }
    public FlightStatus Status { get; set; }
    public bool DirectFlight { get; set; }
}