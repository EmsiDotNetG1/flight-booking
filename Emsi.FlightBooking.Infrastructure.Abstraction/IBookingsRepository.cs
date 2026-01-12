using Emsi.FlightBooking.Infrastructure.DAO;
using Emsi.FlightBooking.Models;

namespace Emsi.FlightBooking.Infrastructure.Abstraction;

public interface IBookingsRepository : ISupportsReadRepository<BookingDao, Guid>, ISupportsWriteRepository<BookingDao, Guid>
{
    
}