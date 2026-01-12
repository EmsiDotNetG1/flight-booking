using Emsi.FlightBooking.Infrastructure.Abstraction;
using Emsi.FlightBooking.Infrastructure.DAO;
using Microsoft.EntityFrameworkCore;

namespace Emsi.FlightBooking.Infrastructure.DataBase.Flights;

public class FlightsRepository : RepositoryBase<DbContext, FlightDao, Guid>, IFlightsRepository
{
    protected FlightsRepository(DbContext context) : base(context)
    {
    }
}