using Application.Shared.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Cards.DeleteCard;

public class DeleteCardCommandHandler : CommandHandler<DeleteCardCommand>
{
    public DeleteCardCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    protected override async Task<Result> HandleCommand(DeleteCardCommand command, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.CardRepository.DeleteAsync(command.Id, cancellationToken);

        await UnitOfWork.SaveAsync(cancellationToken);

        return result
            ? Result.Success()
            : Result.Failure(EntityError<Card>.NotFound(command.Id));
    }
}