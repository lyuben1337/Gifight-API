namespace Domain.Shared;

public class EntityError<T>(string code, string message) : Error(code, message)
    where T : BaseEntity
{
    public static EntityError<T> NotFound(long id)
    {
        return new EntityError<T>($"{typeof(T).Name}.NotFound",
            $"The specified {typeof(T).Name} with id {id} was not found.");
    }
}