using Domain.Shared;

namespace Domain.Entities;

public class Game : ApplicationEntity
{
    public required Deck Deck1 { get; set; }
    public required Deck Deck2 { get; set; }
    public required Deck Winner { get; set; }
    public DateTimeOffset StartedAt { get; set; }
    public DateTimeOffset? EndedAt { get; set; }
}