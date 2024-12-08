using Application.Users.CreateUser;
using Application.Users.DeleteUser;
using Application.Users.GetUser;
using Application.Users.GetUsers;
using Application.Users.UpdateUser;
using Domain.Entities;
using Domain.Shared;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Shared;

namespace Presentation.Controllers;

[Authorize(Roles = "Admin")]
public class UsersController(ISender sender) : ApiController(sender)
{
    [HttpGet]
    public async Task<ActionResult<GetUsersQueryResponse>> GetAll([FromQuery] GetUsersQuery query,
        CancellationToken cancellationToken)
    {
        var response = await Sender.Send(query, cancellationToken);
        if (response.IsSuccess) return Ok(response.Value);

        return BadRequest(response.Error);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<GetUserQueryResponse>> Get(long id, CancellationToken cancellationToken)
    {
        var query = new GetUserQuery(id);
        var response = await Sender.Send(query, cancellationToken);
        if (response.IsSuccess) return Ok(response.Value);

        return NotFound(response.Error);
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateUserCommand command,
        CancellationToken cancellationToken)
    {
        var response = await Sender.Send(command, cancellationToken);
        if (response.IsSuccess) return CreatedAtAction(nameof(Get), new { id = response.Value.Id }, null);

        return BadRequest(response.Error);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        var query = new DeleteUserCommand(id);
        var response = await Sender.Send(query, cancellationToken);
        if (response.IsSuccess) return NoContent();

        return BadRequest(response.Error);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateUserRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.Adapt<UpdateUserCommand>() with { Id = id };
        var response = await Sender.Send(command, cancellationToken);
        if (response.IsSuccess) return NoContent();

        if (response.Error == EntityError<User>.NotFound(id)) return NotFound(response.Error);
        if (response.Error == EntityError<Card>.NotFound(request.CardIds)) return NotFound(response.Error);

        return BadRequest(response.Error);
    }
}