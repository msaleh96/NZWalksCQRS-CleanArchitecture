using API.Region.Requests;
using Application.Regions.Commands.CreateRegion;
using Application.Regions.Commands.DeleteRegion;
using Application.Regions.Commands.UpdateRegion;
using Application.Regions.Queries.GetRegions;
using Application.Regions.Queries.GetRegionById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegionsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await mediator.Send(new GetRegionsQuery());
        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetRegionById")]
    public async Task<IActionResult> Get(Guid id)
    {
        var Region = await mediator.Send(new GetRegionByIdQuery(id));

        return Region is null ? NotFound() : Ok(Region);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateRegionRequest request)
    {
        var command = new CreateRegionCommand(request.Code, request.Name, request.imageUrl);

        var id = await mediator.Send(command);

        return CreatedAtRoute("GetRegionById", new { id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateRegionRequest request)
    {        
        var command = new UpdateRegionCommand(id, request.Code, request.Name, request.imageUrl); 

        if (id != command.Id)
            return BadRequest("Id in URL and request body must match");

        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await mediator.Send(new DeleteRegionCommand(id));
        return NoContent();
    }

}