using System.Text.Json.Serialization;
using Domain.Enums;
using Domain.Shared;

namespace Domain.Entities;

public class User : BaseEntity
{
    public required string Username { get; set; }
    public required string EncryptedPassword { get; set; }
    public UserRole Role { get; set; } = UserRole.Player;
    [JsonIgnore] public List<Card> Cards { get; set; } = [];
    [JsonIgnore] public List<UserCard> UserCards { get; set; } = [];
}