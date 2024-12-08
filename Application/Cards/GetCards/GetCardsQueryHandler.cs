using Application.Cards.DTOs;
using Application.Shared.DTOs;
using Application.Shared.Messaging;
using Domain.Repositories;
using Domain.Shared;
using FluentValidation;
using Mapster;

namespace Application.Cards.GetCards;

public class GetCardsQueryHandler : QueryHandler<GetCardsQuery, GetCardsQueryResponse>
{
    public GetCardsQueryHandler(IUnitOfWork unitOfWork, IValidator<GetCardsQuery> validator)
        : base(unitOfWork, validator)
    {
    }

    protected override async Task<Result<GetCardsQueryResponse>> HandleQuery(GetCardsQuery request,
        CancellationToken cancellationToken)
    {
        var cardsPage = await UnitOfWork.CardRepository.AllAsync(request.Page, request.PageSize, cancellationToken);
        var cardsDtoPage = PageDto<CardDto>.FromPage(cardsPage, user => user.Adapt<CardDto>());

        return Result.Success(new GetCardsQueryResponse(cardsDtoPage));
    }
}