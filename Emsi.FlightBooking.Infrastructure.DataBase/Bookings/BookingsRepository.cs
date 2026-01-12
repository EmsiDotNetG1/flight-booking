using Emsi.FlightBooking.Infrastructure.Abstraction;
using Emsi.FlightBooking.Infrastructure.DAO;
using Emsi.FlightBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace Emsi.FlightBooking.Infrastructure.DataBase.Bookings;

public class BookingsRepository : RepositoryBase<DbContext, BookingDao, Guid>, IBookingsRepository
{
    protected BookingsRepository(DbContext context) : base(context)
    {
    }
}