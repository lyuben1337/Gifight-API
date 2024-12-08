using Application.Shared.Messaging;

namespace Application.Auth.SignUp;

public record SignUpCommand(string Username, string Password) : ICommand<SignUpCommandResponse>;