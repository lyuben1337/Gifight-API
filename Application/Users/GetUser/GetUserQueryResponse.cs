using Application.Users.DTOs;

namespace Application.Users.GetUser;

public record GetUserQueryResponse(
    UserDto User
);