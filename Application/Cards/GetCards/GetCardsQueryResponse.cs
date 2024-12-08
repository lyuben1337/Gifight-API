using Application.Cards.DTOs;
using Domain.Shared;

namespace Application.Cards.GetCards;

public record GetCardsQueryResponse(IPage<CardDto> Cards);