using Application.Cards.DTOs;

namespace Application.Users.DTOs;

public record UserDto(
    long Id,
    string Username,
    List<CardDto> Cards
);