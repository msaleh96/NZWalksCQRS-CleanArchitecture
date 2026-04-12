using API.Walk.Requests;
using Application.Walks.Commands.CreateWalk;
using Application.Walks.Commands.DeleteWalk;
using Application.Walks.Commands.UpdateWalk;
using Application.Walks.Queries.GetWalks;
using Application.Walks.Queries.GetWalkById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using API.Common;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WalksController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        var result = await mediator.Send(new GetWalksQuery(pageNumber, pageSize));

        return result.ToApiResponse();
    }

    [HttpGet("{id}", Name = "GetWalkById")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await mediator.Send(new GetWalkByIdQuery(id));

        return result.ToApiResponse();
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateWalkRequest request)
    {
        var command = new CreateWalkCommand(request.Name, request.Description, request.LengthInKm, request.DifficultyId, request.RegionId, request.imageUrl);

        var result = await mediator.Send(command);

        return result.ToCreatedResponse(
            "GetWalkById",
            x => new { id = x.Id }
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateWalkRequest request)
    {        
        var command = new UpdateWalkCommand(id, request.Name, request.Description, request.LengthInKm, request.DifficultyId, request.RegionId, request.imageUrl); 

        var result = await mediator.Send(command);
        return result.ToApiResponse();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteWalkCommand(id));
        return result.ToApiResponse();
    }

}