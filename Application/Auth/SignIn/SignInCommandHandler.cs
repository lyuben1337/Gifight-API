using Application.Shared.Messaging;
using Application.Shared.Services;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Auth.SignIn;

public class SignInCommandHandler : CommandHandler<SignInCommand, SignInCommandResponse>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IPasswordEncoder _passwordEncoder;

    public SignInCommandHandler(IUnitOfWork unitOfWork, IJwtProvider jwtProvider, IPasswordEncoder passwordEncoder) :
        base(unitOfWork)
    {
        _jwtProvider = jwtProvider;
        _passwordEncoder = passwordEncoder;
    }

    protected override async Task<Result<SignInCommandResponse>> HandleCommand(SignInCommand request,
        CancellationToken cancellationToken)
    {
        var user = await UnitOfWork.UserRepository.GetByUsernameAsync(request.Username.ToLower(), cancellationToken);

        if (user == null)
            return Result.Failure<SignInCommandResponse>(UserError.InvalidCredentials);

        if (!_passwordEncoder.Verify(request.Password, user.EncryptedPassword))
            return Result.Failure<SignInCommandResponse>(UserError.InvalidCredentials);

        var token = _jwtProvider.Generate(user);
        return Result.Success(new SignInCommandResponse(token));
    }
}