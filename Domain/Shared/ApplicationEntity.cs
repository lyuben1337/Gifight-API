namespace Domain.Shared;

public abstract class ApplicationEntity
{
    public required long Id { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public required DateTimeOffset UpdatedAt { get; set; }
}