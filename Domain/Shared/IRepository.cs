namespace Domain.Shared;

public interface IRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> All();
    Task<T?> GetById(int id);

    Task<bool> Add(T entity);

    Task<bool> Delete(int id); 
}