using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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

    public virtual async Task<IEnumerable<T>> All()
    {
        return await Set.ToListAsync();
    }

    public virtual async Task<T?> GetById(int id)
    {
        try
        {
            return await Set.FindAsync(id);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public virtual async Task<bool> Add(T entity)
    {
        try
        {
            await Set.AddAsync(entity);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public virtual async Task<bool> Delete(int id)
    {
        try
        {
            var entity = await Set.FindAsync(id);
            if (entity != null)
            {
                Set.Remove(entity);
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }
}