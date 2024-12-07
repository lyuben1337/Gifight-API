using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Shared;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    protected readonly ISender Sender;

    protected ApiController(ISender sender)
    {
        Sender = sender;
    }
}