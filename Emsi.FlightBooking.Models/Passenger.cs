#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
namespace Emsi.FlightBooking.Models;

public class Passenger
{
    public Guid Id { get; set; }
    public string Civility { get; set; }
    public DateTime CreatedAt { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Passport { get; set; }
    public string Email { get; set; }
}