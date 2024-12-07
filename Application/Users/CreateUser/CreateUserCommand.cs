using Application.Shared;
using Domain.Shared;
using MediatR;

namespace Application.Users.CreateUser;

public record CreateUserCommand(
    string Username,
    string Password
) : ICommand<CreateUserResponse>;