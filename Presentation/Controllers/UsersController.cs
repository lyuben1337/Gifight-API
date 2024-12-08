using Application.Users.CreateUser;
using Application.Users.DeleteUser;
using Application.Users.GetUser;
using Application.Users.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Shared;

namespace Presentation.Controllers;

public class UsersController(ISender sender) : ApiController(sender)
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetUsersQuery query, CancellationToken cancellationToken)
    {
        var response = await Sender.Send(query, cancellationToken);
        if (response.IsSuccess) return Ok(response.Value);

        return BadRequest(response.Error);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
    {
        var query = new GetUserQuery(id);
        var response = await Sender.Send(query, cancellationToken);
        if (response.IsSuccess) return Ok(response.Value);

        return NotFound(response.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var response = await Sender.Send(command, cancellationToken);
        if (response.IsSuccess) return CreatedAtAction(nameof(Get), new { id = response.Value.Id }, null);

        return BadRequest(response.Error);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        var query = new DeleteUserCommand(id);
        var response = await Sender.Send(query, cancellationToken);
        if (response.IsSuccess) return NoContent();

        return BadRequest(response.Error);
    }
}