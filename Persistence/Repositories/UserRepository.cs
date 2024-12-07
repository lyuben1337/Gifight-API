using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Shared;

namespace Persistence.Repositories;

public class UserRepository(DbContext context) : Repository<User>(context), IUserRepository
{
    
}