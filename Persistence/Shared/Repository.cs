using Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Shared;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    protected DbContext Context;
    protected DbSet<T> Set;

    public Repository(DbContext context)
    {
        Context = context;
        Set = Context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> AllAsync(CancellationToken cancellationToken = default)
    {
        return await Set.ToListAsync(cancellationToken);
    }

    public virtual async Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        try
        {
            return await Set.FindAsync([id], cancellationToken);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public virtual async Task<bool> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        try
        {
            await Set.AddAsync(entity, cancellationToken);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public virtual async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            if (entity == null) return false;
            Set.Remove(entity);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}