using Domain.Enums;
using Domain.Shared;

namespace Domain.Entities;

public class GameRequest : ApplicationEntity
{
    public required User Sender { get; set; }
    public required long SenderId { get; set; }
    public required User Receiver { get; set; }
    public required long ReceiverId { get; set; }
    public required GameRequestStatus Status { get; set; } = GameRequestStatus.Pending;
}