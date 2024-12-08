using Application.Shared.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;
using FluentValidation;

namespace Application.Users.UpdateUser;

public class UpdateUserCommandHandler : CommandHandler<UpdateUserCommand>
{
    public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateUserCommand> validator)
        : base(unitOfWork, validator)
    {
    }

    protected override async Task<Result> HandleCommand(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await UnitOfWork.UserRepository.GetByIdAsync(command.Id, cancellationToken);
        if (user == null) return Result.Failure(EntityError<User>.NotFound(command.Id));

        var allExist = await UnitOfWork.CardRepository.AllExistByIdsAsync(command.CardIds, cancellationToken);
        if (!allExist) return Result.Failure(EntityError<Card>.NotFound(command.CardIds));

        var cards = await UnitOfWork.CardRepository.AllByIdsAsync(command.CardIds, cancellationToken);

        user.UserCards.Clear();

        foreach (var card in cards)
            user.UserCards.Add(new UserCard
            {
                UserId = user.Id,
                User = user,
                CardId = card.Id,
                Card = card
            });

        UnitOfWork.UserRepository.Update(user);
        await UnitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}