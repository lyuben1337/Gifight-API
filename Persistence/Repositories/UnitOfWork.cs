using Domain.Repositories;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        CardRepository = new CardRepository(_context);
        UserRepository = new UserRepository(_context);
        GameRepository = new GameRepository(_context);
    }

    public ICardRepository CardRepository { get; }
    public IUserRepository UserRepository { get; }
    public IGameRepository GameRepository { get; }

    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        var entities = _context.ChangeTracker.Entries()
            .Where(e => e is { Entity: BaseEntity, State: EntityState.Modified })
            .Select(e => (BaseEntity)e.Entity);

        foreach (var entity in entities) entity.UpdatedAt = DateTimeOffset.Now;

        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}