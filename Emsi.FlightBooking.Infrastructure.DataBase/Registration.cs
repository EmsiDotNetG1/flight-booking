using Emsi.FlightBooking.Infrastructure.Abstraction;
using Emsi.FlightBooking.Infrastructure.DataBase.Bookings;
using Emsi.FlightBooking.Infrastructure.DataBase.Flights;
using Emsi.FlightBooking.Infrastructure.DataBase.Passengers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Emsi.FlightBooking.Infrastructure.DataBase;

public static class Registration
{
    public static IServiceCollection AddDatabaseDependencies(this IServiceCollection services, string connectionString)
    {
        // create all objects in IOS container
        
        //Repositories
        services.AddScoped<IPassengersRepository, PassengersRepository>();
        services.AddScoped<IBookingsRepository, BookingsRepository>();
        services.AddScoped<IFlightsRepository, FlightsRepository>();
        
        //Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>(provider => provider.GetRequiredService<UnitOfWork>());
        
        //Db Context
        services.AddDbContext<UnitOfWork>(options => options.UseNpgsql(connectionString));
        return services;
    }
}