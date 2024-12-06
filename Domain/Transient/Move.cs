using Domain.Entities;
using Domain.Shared;

namespace Domain.Transient;

public class Move : TransientModel
{
    public required User Player { get; set; }
    public required Card Card { get; set; }
}