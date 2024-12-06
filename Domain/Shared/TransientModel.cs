namespace Domain.Shared;

public abstract class TransientModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
}