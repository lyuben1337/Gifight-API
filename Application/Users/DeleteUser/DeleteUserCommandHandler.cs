using Application.Shared.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Users.DeleteUser;

public class DeleteUserCommandHandler : CommandHandler<DeleteUserCommand>
{
    public DeleteUserCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    protected override async Task<Result> HandleCommand(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.UserRepository.DeleteAsync(command.Id, cancellationToken);

        await UnitOfWork.SaveAsync(cancellationToken);

        return result
            ? Result.Success()
            : Result.Failure(EntityError<User>.NotFound(command.Id));
    }
}