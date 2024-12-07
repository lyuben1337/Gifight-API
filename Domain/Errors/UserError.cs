using Domain.Entities;
using Domain.Shared;

namespace Domain.Errors;

public class UserError(string code, string message) : EntityError<User>(code, message)
{
    public static UserError UsernameOccupied(string username)
    {
        return new UserError($"User.UsernameOccupied", $"The username '{username}' is already taken.");
    }
}