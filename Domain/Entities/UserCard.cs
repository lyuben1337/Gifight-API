using Domain.Shared;

namespace Domain.Entities;

public class UserCard : BaseEntity
{
    public required long UserId { get; set; }
    public required User User { get; set; }
    public required long CardId { get; set; }
    public required Card Card { get; set; }
}