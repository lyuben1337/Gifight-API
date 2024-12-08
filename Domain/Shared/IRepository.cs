namespace Domain.Shared;

public interface IRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> AllAsync(CancellationToken cancellationToken);
    Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken);

    Task<bool> AddAsync(T entity, CancellationToken cancellationToken);

    Task<bool> DeleteAsync(long id, CancellationToken cancellationToken);
}