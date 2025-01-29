using System.Text.Json.Serialization;

namespace Domain.Shared;

public abstract class BaseEntity
{
    [JsonIgnore] public long Id { get; set; }

    [JsonIgnore] public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    [JsonIgnore] public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}