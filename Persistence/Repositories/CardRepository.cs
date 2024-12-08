using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence.Shared;

namespace Persistence.Repositories;

public class CardRepository(DbContext context) : Repository<Card>(context), ICardRepository
{

}