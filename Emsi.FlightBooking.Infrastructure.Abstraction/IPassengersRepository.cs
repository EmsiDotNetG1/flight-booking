using Emsi.FlightBooking.Infrastructure.DAO;
using Emsi.FlightBooking.Models;

namespace Emsi.FlightBooking.Infrastructure.Abstraction;

public interface IPassengersRepository : ISupportsReadRepository<PassengerDao, Guid>, ISupportsWriteRepository<PassengerDao, Guid>
{
    
}