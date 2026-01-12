using Emsi.FlightBooking.Infrastructure.DAO;
using Emsi.FlightBooking.Models;

namespace Emsi.FlightBooking.Infrastructure.Abstraction;

public interface IFlightsRepository : ISupportsReadRepository<FlightDao, Guid>, ISupportsWriteRepository<FlightDao, Guid>
{
    
}