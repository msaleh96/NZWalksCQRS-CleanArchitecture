using API.Walk.Requests;
using Application.Walks.Commands.CreateWalk;
using Application.Walks.Commands.DeleteWalk;
using Application.Walks.Commands.UpdateWalk;
using Application.Walks.Queries.GetWalks;
using Application.Walks.Queries.GetWalkById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WalksController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await mediator.Send(new GetWalksQuery());
        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetWalkById")]
    public async Task<IActionResult> Get(Guid id)
    {
        var Walk = await mediator.Send(new GetWalkByIdQuery(id));

        return Walk is null ? NotFound() : Ok(Walk);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateWalkRequest request)
    {
        var command = new CreateWalkCommand(request.Name, request.Description, request.LengthInKm, request.DifficultyId, request.RegionId, request.imageUrl);

        var id = await mediator.Send(command);

        return CreatedAtRoute("GetWalkById", new { id }, new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateWalkRequest request)
    {        
        var command = new UpdateWalkCommand(id, request.Name, request.Description, request.LengthInKm, request.DifficultyId, request.RegionId, request.imageUrl); 

        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await mediator.Send(new DeleteWalkCommand(id));
        return NoContent();
    }

}