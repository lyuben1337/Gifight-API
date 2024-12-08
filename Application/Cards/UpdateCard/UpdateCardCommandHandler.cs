using Application.Shared.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;
using FluentValidation;

namespace Application.Cards.UpdateCard;

public class UpdateCardCommandHandler : CommandHandler<UpdateCardCommand>
{
    public UpdateCardCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateCardCommand> validator)
        : base(unitOfWork, validator)
    {
    }

    protected override async Task<Result> HandleCommand(UpdateCardCommand command, CancellationToken cancellationToken)
    {
        var card = await UnitOfWork.CardRepository.GetByIdAsync(command.Id, cancellationToken);
        if (card == null) return Result.Failure(EntityError<Card>.NotFound(command.Id));

        card.ImageUrl = command.ImageUrl;
        card.Power = command.Power;
        card.Title = command.Title;

        UnitOfWork.CardRepository.Update(card);
        await UnitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}