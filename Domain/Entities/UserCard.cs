using Domain.Shared;

namespace Domain.Entities;

public class UserCard : ApplicationEntity
{
    public required long UserId { get; set; }
    public required long CardId { get; set; }
}