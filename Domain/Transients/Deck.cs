using Domain.Entities;
using Domain.Shared;

namespace Domain.Transient;

public class Deck : BaseTransient
{
    public required User Player { get; set; }
    public List<Card> Cards { get; set; } = [];
}