namespace Application.Users.DTOs;

public record UserShortDto(
    long Id,
    string Username,
    string Role
);