using Application.Shared.Messaging;

namespace Application.Auth.SignIn;

public record SignInCommand(string Username, string Password) : ICommand<SignInCommandResponse>;