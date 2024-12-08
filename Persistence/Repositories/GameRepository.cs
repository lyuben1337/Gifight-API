using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Shared;

namespace Persistence.Repositories;

public class GameRepository(DbContext context) : Repository<Game>(context), IGameRepository
{

}