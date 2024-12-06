using Domain.Shared;

namespace Domain.Entities;

public class Game : ApplicationEntity
{
    public required List<User> Players { get; set; } = [];
    public required List<GamePlayer> GamePlayers { get; set; } = [];
    public required User Winner { get; set; }
    public required DateTimeOffset StartedAt { get; set; }
    public required DateTimeOffset EndedAt { get; set; }
}