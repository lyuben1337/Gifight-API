using Domain.Enums;
using Domain.Shared;

namespace Domain.Entities;

public class User : BaseEntity
{
    public required string Username { get; set; }
    public required string EncryptedPassword { get; set; }
    public required UserRole Role { get; set; } = UserRole.Player;
    public required List<Card> Cards { get; set; } = [];
    public required List<UserCard> UserCards { get; set; } = [];
}