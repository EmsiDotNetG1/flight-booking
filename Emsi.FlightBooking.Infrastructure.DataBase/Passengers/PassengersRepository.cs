using Emsi.FlightBooking.Infrastructure.Abstraction;
using Emsi.FlightBooking.Infrastructure.DAO;
using Emsi.FlightBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace Emsi.FlightBooking.Infrastructure.DataBase.Passengers;

public class PassengersRepository : RepositoryBase<DbContext, PassengerDao, Guid>, IPassengersRepository
{
    protected PassengersRepository(DbContext context) : base(context)
    {
    }
}