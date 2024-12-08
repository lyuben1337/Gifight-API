using Application.Cards.CreateCard;
using Application.Cards.DeleteCard;
using Application.Cards.GetCard;
using Application.Cards.GetCards;
using Application.Cards.UpdateCard;
using Domain.Entities;
using Domain.Shared;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Shared;

namespace Presentation.Controllers;

public class CardsController(ISender sender) : ApiController(sender)
{
    [HttpGet]
    public async Task<ActionResult<GetCardsQueryResponse>> GetAll([FromQuery] GetCardsQuery query,
        CancellationToken cancellationToken)
    {
        var response = await Sender.Send(query, cancellationToken);
        if (response.IsSuccess) return Ok(response.Value);

        return BadRequest(response.Error);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<GetCardQueryResponse>> Get(long id, CancellationToken cancellationToken)
    {
        var query = new GetCardQuery(id);
        var response = await Sender.Send(query, cancellationToken);
        if (response.IsSuccess) return Ok(response.Value);

        return NotFound(response.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCardCommand command, CancellationToken cancellationToken)
    {
        var response = await Sender.Send(command, cancellationToken);
        if (response.IsSuccess) return CreatedAtAction(nameof(Get), new { id = response.Value.Id }, null);

        return BadRequest(response.Error);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        var query = new DeleteCardCommand(id);
        var response = await Sender.Send(query, cancellationToken);
        if (response.IsSuccess) return NoContent();

        return BadRequest(response.Error);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateCardRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.Adapt<UpdateCardCommand>() with { Id = id };
        var response = await Sender.Send(command, cancellationToken);
        if (response.IsSuccess) return NoContent();

        if (response.Error == EntityError<Card>.NotFound(id)) return NotFound(response.Error);

        return BadRequest(response.Error);
    }
}