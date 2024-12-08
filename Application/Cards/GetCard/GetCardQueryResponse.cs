using Application.Cards.DTOs;

namespace Application.Cards.GetCard;

public record GetCardQueryResponse(
    CardDto Card
);