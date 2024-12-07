namespace Domain.Shared;

public abstract class BaseTransient
{
    public Guid Id { get; set; } = Guid.NewGuid();
}