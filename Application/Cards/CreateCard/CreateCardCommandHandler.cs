using Application.Shared.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;
using FluentValidation;
using Mapster;

namespace Application.Cards.CreateCard;

public class CreateCardCommandHandler : CommandHandler<CreateCardCommand, CreateCardCommandResponse>
{
    public CreateCardCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateCardCommand> validator)
        : base(unitOfWork, validator)
    {
    }

    protected override async Task<Result<CreateCardCommandResponse>> HandleCommand(CreateCardCommand request,
        CancellationToken cancellationToken)
    {
        var card = request.Adapt<Card>();

        await UnitOfWork.CardRepository.AddAsync(card, cancellationToken);
        await UnitOfWork.SaveAsync(cancellationToken);

        return Result.Success(card.Adapt<CreateCardCommandResponse>());
    }
}