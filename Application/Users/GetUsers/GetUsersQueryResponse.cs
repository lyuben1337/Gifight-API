using Application.Users.DTOs;
using Domain.Shared;

namespace Application.Users.GetUsers;

public record GetUsersQueryResponse(IPage<UserDto> Users);