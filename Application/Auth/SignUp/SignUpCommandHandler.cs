using Application.Shared.Messaging;
using Application.Shared.Services;
using Domain.Entities;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using FluentValidation;

namespace Application.Auth.SignUp;

public class SignUpCommandHandler : CommandHandler<SignUpCommand, SignUpCommandResponse>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IPasswordEncoder _passwordEncoder;

    public SignUpCommandHandler(
        IUnitOfWork unitOfWork,
        IValidator<SignUpCommand> validator,
        IJwtProvider jwtProvider,
        IPasswordEncoder passwordEncoder
    ) : base(unitOfWork, validator)
    {
        _jwtProvider = jwtProvider;
        _passwordEncoder = passwordEncoder;
    }

    protected override async Task<Result<SignUpCommandResponse>> HandleCommand(SignUpCommand request,
        CancellationToken cancellationToken)
    {
        var user = new User
        {
            Username = request.Username.ToLower(),
            EncryptedPassword = _passwordEncoder.Encode(request.Password)
        };

        var isUsernameOccupied =
            await UnitOfWork.UserRepository.ExistsByUsernameAsync(user.Username, cancellationToken);

        if (isUsernameOccupied)
            return Result.Failure<SignUpCommandResponse>(UserError.UsernameOccupied(user.Username));

        await UnitOfWork.UserRepository.AddAsync(user, cancellationToken);
        await UnitOfWork.SaveAsync(cancellationToken);

        var createdUser = await UnitOfWork.UserRepository.GetByUsernameAsync(user.Username, cancellationToken);
        var token = _jwtProvider.Generate(createdUser!);

        return Result.Success(new SignUpCommandResponse(token));
    }
}