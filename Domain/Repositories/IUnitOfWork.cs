namespace Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    ICardRepository CardRepository { get; }
    IUserRepository UserRepository { get; }
    IGameRepository GameRepository { get; }
    Task<int> SaveAsync(CancellationToken cancellationToken = default);
}