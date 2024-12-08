using Application.Cards.DTOs;
using Domain.Enums;

namespace Application.Users.DTOs;

public record UserDto(
    long Id,
    string Username,
    UserRole Role,
    List<CardDto> Cards
);