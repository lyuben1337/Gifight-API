using Domain.Enums;
using Domain.Shared;

namespace Domain.Entities;

public class User : ApplicationEntity
{
    public required string Username { get; set; }
    public required string EncryptedPassword { get; set; }
    public required UserRole Role { get; set; } = UserRole.Player;
    public List<Card> Cards { get; set; } = [];
}