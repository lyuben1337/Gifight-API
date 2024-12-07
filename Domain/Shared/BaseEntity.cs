namespace Domain.Shared;

public abstract class BaseEntity
{
    public required long Id { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public required DateTimeOffset UpdatedAt { get; set; }
}