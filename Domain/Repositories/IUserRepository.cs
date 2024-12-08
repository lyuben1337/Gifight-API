using Domain.Entities;
using Domain.Shared;

namespace Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken);
    Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
}