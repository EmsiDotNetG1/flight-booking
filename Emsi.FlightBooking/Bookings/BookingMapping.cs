using Emsi.FlightBooking.Infrastructure.DAO;
using Emsi.FlightBooking.Models;
using Mapster;

namespace Emsi.FlightBooking.Bookings;

public class BookingMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Booking, BookingDao>();
        config.NewConfig<BookingDao, Booking>();
    }
}