using Application.Shared.Messaging;
using MediatR;

namespace Application.Users.DeleteUser;

public record DeleteUserCommand(
    long Id
) : ICommand<Unit>;