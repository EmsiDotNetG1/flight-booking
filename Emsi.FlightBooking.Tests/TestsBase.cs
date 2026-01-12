using AutoFixture;
using Emsi.FlightBooking.Bookings;
using Mapster;
using MapsterMapper;

namespace Emsi.FlightBooking.Tests;

public abstract class TestsBase
{
    protected IMapper Mapper { get; }
    protected Fixture  Fixture { get; }

    protected TestsBase()
    {
        Fixture = new Fixture();

        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(BookingMapping).Assembly);
        Mapper = new Mapper(config);
    }
}