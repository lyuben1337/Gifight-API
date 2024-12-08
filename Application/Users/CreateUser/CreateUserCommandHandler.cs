using Application.Shared.Messaging;
using Domain.Entities;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using FluentValidation;
using Mapster;

namespace Application.Users.CreateUser;

public class CreateUserCommandHandler : CommandHandler<CreateUserCommand, CreateUserResponse>
{
    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateUserCommand> validator)
        : base(unitOfWork, validator)
    {
    }

    protected override async Task<Result<CreateUserResponse>> HandleCommand(CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = new User
        {
            Username = request.Username.ToLower(),
            EncryptedPassword = request.Password
        };

        var isUsernameOccupied =
            await UnitOfWork.UserRepository.ExistsByUsernameAsync(user.Username, cancellationToken);

        if (isUsernameOccupied)
            return Result.Failure<CreateUserResponse>(UserError.UsernameOccupied(user.Username));

        await UnitOfWork.UserRepository.AddAsync(user, cancellationToken);
        await UnitOfWork.SaveAsync(cancellationToken);

        return Result.Success(user.Adapt<CreateUserResponse>());
    }
}