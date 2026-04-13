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
public class WalksController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        return await Send(new GetWalksQuery(pageNumber, pageSize));
    }

    [HttpGet("{id}", Name = "GetWalkById")]
    public async Task<IActionResult> Get(Guid id)
    {
        return await Send(new GetWalkByIdQuery(id));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateWalkRequest request)
    {
        var command = new CreateWalkCommand(request.Name, request.Description, request.LengthInKm, request.DifficultyId, request.RegionId, request.imageUrl);

        return await SendCreate(
            command,
            "GetWalkById",
            x => new { id = x.Id }
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateWalkRequest request)
    {        
        var command = new UpdateWalkCommand(id, request.Name, request.Description, request.LengthInKm, request.DifficultyId, request.RegionId, request.imageUrl); 

        return await Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return await Send(new DeleteWalkCommand(id));
    }

}