using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Shared;

namespace Presentation.Controllers;

public class UsersController(ISender sender) : ApiController(sender)
{
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetUserById(long id, CancellationToken cancellationToken)
    {
        return Ok(id);
    }
}