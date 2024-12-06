using Domain.Shared;

namespace Domain.Entities;

public class GamePlayer : ApplicationEntity
{
    public required long GameId { get; set; }
    public required Game Game { get; set; }
    public required long PlayerId { get; set; }
    public required User Player { get; set; }
}