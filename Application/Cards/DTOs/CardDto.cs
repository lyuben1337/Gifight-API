namespace Application.Cards.DTOs;

public record CardDto(
    long Id,
    string Title,
    string ImageUrl,
    int Power
);