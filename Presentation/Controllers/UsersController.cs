using Application.Users.CreateUser;
using Application.Users.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Shared;

namespace Presentation.Controllers;

public class UsersController(ISender sender) : ApiController(sender)
{
    [HttpGet("{id:long}")]
    public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
    {
        var query = new GetUserQuery(id);

        var response = await Sender.Send(query, cancellationToken);
        if (response.IsSuccess) return Ok(response.Value);

        return NotFound(response.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var response = await Sender.Send(request, cancellationToken);
        if (response.IsSuccess) return Created();

        return BadRequest(response.Error);
    }
}