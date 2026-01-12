using Emsi.FlightBooking.Abstractions;
using Emsi.FlightBooking.Bookings;
using Emsi.FlightBooking.Flights;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Emsi.FlightBooking;

public static class Registration
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        //services
        services.AddScoped<IFlightsService, FlightsService>();
        services.AddScoped<IBookingsService, BookingsService>();
        
        //mapster
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(Registration).Assembly);
        services.AddSingleton(config);
        services.AddScoped<IMapper,  Mapper>();
        return services;

    }
}