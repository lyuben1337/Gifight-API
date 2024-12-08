using Application.Auth.SignIn;
using Application.Auth.SignUp;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Shared;

namespace Presentation.Controllers;

[Route("[action]")]
public class AuthController(ISender sender) : ApiController(sender)
{
    [HttpPost]
    public async Task<ActionResult<SignInCommandResponse>> SignIn(SignInCommand command,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(command, cancellationToken);
        if (result.IsSuccess) return Ok(result.Value);
        return Unauthorized(result.Error);
    }

    [HttpPost]
    public async Task<ActionResult<SignUpCommandResponse>> SignUp(SignUpCommand command,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(command, cancellationToken);
        if (result.IsSuccess) return Ok(result.Value);
        return BadRequest(result.Error);
    }
}