using Application.Shared.Messaging;
using MediatR;

namespace Application.Users.UpdateUser;

public record UpdateUserCommand(
    long Id,
    List<long> CardIds
) : ICommand<Unit>;

public record UpdateUserRequest(
    List<long> CardIds
);