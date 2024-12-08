using Application.Cards.DTOs;

namespace Application.Users.DTOs;

public record UserDto(
    long Id,
    string Username,
    string Role,
    List<CardDto> Cards
);