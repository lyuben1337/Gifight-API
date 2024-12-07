using Domain.Entities;
using Domain.Shared;

namespace Domain.Transients;

public class Move : BaseTransient
{
    public required User Player { get; set; }
    public required Card Card { get; set; }
}