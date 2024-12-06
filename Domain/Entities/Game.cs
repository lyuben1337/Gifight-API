using Domain.Shared;

namespace Domain.Entities;

public class Game : ApplicationEntity
{
    public required Deck Deck1 { get; set; }
    public required long Deck1Id { get; set; }
    public required Deck Deck2 { get; set; }
    public required long Deck2Id { get; set; }
    public required Deck Winner { get; set; }
    public required long WinnerId { get; set; }
    public DateTimeOffset StartedAt { get; set; }
    public DateTimeOffset? EndedAt { get; set; }

    public required List<Move> Moves { get; set; } = [];
}