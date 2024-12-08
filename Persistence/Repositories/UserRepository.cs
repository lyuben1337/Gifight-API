using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Shared;

namespace Persistence.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }

    public Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        return Set.AnyAsync(u => u.Username == username, cancellationToken);
    }

    public override async Task<User?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await Set
            .Include(u => u.UserCards)
            .ThenInclude(uc => uc.Card)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }
}