using Emsi.FlightBooking.Infrastructure.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Emsi.FlightBooking.Infrastructure.DataBase;

public class RepositoryBase<TDbContext, TEntity, TPk> : ISupportsReadRepository<TEntity, TPk>, ISupportsWriteRepository<TEntity, TPk>
    where TEntity : class
    where TPk : struct
    where TDbContext : DbContext
{
    protected readonly TDbContext Context;
    protected readonly DbSet<TEntity> Set;
    
    protected RepositoryBase(TDbContext context)
    {
        Context = context;
        Set = context.Set<TEntity>();
    }
    
    public async Task<TEntity?> GetByIdAsync(TPk id)
    {
        return await Set.FindAsync(id);
    }

    public IQueryable<TEntity> GetAll()
    {
        return Set.AsNoTracking().AsQueryable();
    }
 
    public async Task AddAsync(TEntity entity)
    {
        Set.Add(entity);
        var affected = await Context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        Set.Update(entity);
        var affected = await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TPk id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null)
            return;
        
        Set.Remove(entity);
        
        var affected = await Context.SaveChangesAsync();
    }
}