namespace Emsi.FlightBooking.Infrastructure.Abstraction;

public interface ISupportsWriteRepository<T, TPk> where T : class where TPk : struct
{
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(TPk id);
}