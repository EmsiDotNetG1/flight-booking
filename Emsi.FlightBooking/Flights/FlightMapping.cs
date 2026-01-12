using Emsi.FlightBooking.Infrastructure.DAO;
using Emsi.FlightBooking.Models;
using Mapster;

namespace Emsi.FlightBooking.Flights;

public class FlightMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<FlightDao, Flight>();
        config.NewConfig<Flight, FlightDao>();
    }
}