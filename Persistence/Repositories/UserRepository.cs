using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Shared;

namespace Persistence.Repositories;

public class UserRepository(DbContext context) : Repository<User>(context), IUserRepository
{
    public Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        return Set.AnyAsync(u => u.Username == username, cancellationToken);
    }
}