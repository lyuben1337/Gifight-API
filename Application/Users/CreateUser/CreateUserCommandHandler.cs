using Application.Shared.Messaging;
using Application.Shared.Services.Security;
using Domain.Entities;
using Domain.Enums;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using FluentValidation;
using Mapster;

namespace Application.Users.CreateUser;

public class CreateUserCommandHandler : CommandHandler<CreateUserCommand, CreateUserCommandResponse>
{
    private readonly IPasswordEncoder _passwordEncoder;

    public CreateUserCommandHandler(
        IUnitOfWork unitOfWork,
        IValidator<CreateUserCommand> validator,
        IPasswordEncoder passwordEncoder
    ) : base(unitOfWork, validator)
    {
        _passwordEncoder = passwordEncoder;
    }

    protected override async Task<Result<CreateUserCommandResponse>> HandleCommand(CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = new User
        {
            Username = request.Username.ToLower(),
            EncryptedPassword = _passwordEncoder.Encode(request.Password),
            Role = Enum.Parse<UserRole>(request.Role)
        };

        var isUsernameOccupied =
            await UnitOfWork.UserRepository.ExistsByUsernameAsync(user.Username, cancellationToken);

        if (isUsernameOccupied)
            return Result.Failure<CreateUserCommandResponse>(UserError.UsernameOccupied(user.Username));

        await UnitOfWork.UserRepository.AddAsync(user, cancellationToken);
        await UnitOfWork.SaveAsync(cancellationToken);

        return Result.Success(user.Adapt<CreateUserCommandResponse>());
    }
}