namespace Emsi.FlightBooking.Infrastructure.Abstraction;

public interface ISupportsReadRepository<T, TPk> where T : class where TPk : struct
{
    Task<T?> GetByIdAsync(TPk id);
    IQueryable<T> GetAll();
}