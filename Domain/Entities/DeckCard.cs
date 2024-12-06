using Domain.Shared;

namespace Domain.Entities;

public class DeckCard : ApplicationEntity
{
    public required long DeckId { get; set; }
    public required Card Card { get; set; }
    public bool Available { get; set; } = true;
}