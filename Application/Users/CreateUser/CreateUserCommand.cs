using Application.Shared.Messaging;

namespace Application.Users.CreateUser;

public record CreateUserCommand(
    string Username,
    string Password
) : ICommand<CreateUserResponse>;