using Domain.Shared;

namespace Domain.Entities;

public class Move : ApplicationEntity
{
    public required Game Game { get; set; }
    public required long GameId { get; set; }
    public required Deck Deck { get; set; }
    public required long DeckId { get; set; }
    public required Card Card { get; set; }
    public required long CardId { get; set; }
}