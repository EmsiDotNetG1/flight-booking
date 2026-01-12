namespace Emsi.FlightBooking.Infrastructure.Abstraction;

public interface IUnitOfWork
{
    Task<int> CommitAsync();
}