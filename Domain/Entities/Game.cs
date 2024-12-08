using System.Text.Json.Serialization;
using Domain.Shared;

namespace Domain.Entities;

public class Game : BaseEntity
{
    [JsonIgnore] public List<User> Players { get; set; } = [];
    [JsonIgnore] public List<GamePlayer> GamePlayers { get; set; } = [];
    [JsonIgnore] public User Winner { get; set; }
    public required long WinnerId { get; set; }
    public required DateTimeOffset StartedAt { get; set; }
    public required DateTimeOffset EndedAt { get; set; }
}