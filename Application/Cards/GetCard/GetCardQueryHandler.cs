using Application.Cards.DTOs;
using Application.Shared.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;
using FluentValidation;
using Mapster;

namespace Application.Cards.GetCard;

public class GetCardQueryHandler : QueryHandler<GetCardQuery, GetCardQueryResponse>
{
    public GetCardQueryHandler(IUnitOfWork unitOfWork, IValidator<GetCardQuery>? validator = null) : base(unitOfWork,
        validator)
    {
    }

    protected override async Task<Result<GetCardQueryResponse>> HandleQuery(GetCardQuery request,
        CancellationToken cancellationToken)
    {
        var card = await UnitOfWork.CardRepository.GetByIdAsync(request.Id, cancellationToken);

        return card == null
            ? Result.Failure<GetCardQueryResponse>(EntityError<Card>.NotFound(request.Id))
            : Result.Success(new GetCardQueryResponse(card.Adapt<CardDto>()));
    }
}