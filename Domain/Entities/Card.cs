using Domain.Shared;

namespace Domain.Entities;

public class Card : ApplicationEntity
{
    public required string Title { get; set; }
    public required string ImageUrl { get; set; }
    public required string Power { get; set; }
}