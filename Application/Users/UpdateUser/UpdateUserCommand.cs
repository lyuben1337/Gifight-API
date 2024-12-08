using Application.Shared.Messaging;
using Domain.Enums;
using MediatR;

namespace Application.Users.UpdateUser;

public record UpdateUserCommand(
    long Id,
    List<long> CardIds,
    UserRole Role
) : ICommand<Unit>;

public record UpdateUserRequest(
    List<long> CardIds
);