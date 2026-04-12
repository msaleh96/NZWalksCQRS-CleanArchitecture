using API.Region.Requests;
using Application.Regions.Commands.CreateRegion;
using Application.Regions.Commands.DeleteRegion;
using Application.Regions.Commands.UpdateRegion;
using Application.Regions.Queries.GetRegions;
using Application.Regions.Queries.GetRegionById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using API.Common;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegionsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await mediator.Send(new GetRegionsQuery());
        return result.ToApiResponse();
    }

    [HttpGet("{id}", Name = "GetRegionById")]
    public async Task<IActionResult> Get(Guid id)
    {
        var region = await mediator.Send(new GetRegionByIdQuery(id));

        return region.ToApiResponse();
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateRegionRequest request)
    {
        var command = new CreateRegionCommand(request.Code, request.Name, request.imageUrl);

        var result = await mediator.Send(command);

        return result.ToCreatedResponse(
            "GetRegionById",
            x => new { id = x.Id }
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateRegionRequest request)
    {        
        var command = new UpdateRegionCommand(id, request.Code, request.Name, request.imageUrl); 

        var result = await mediator.Send(command);
        return result.ToApiResponse();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteRegionCommand(id));
        return result.ToApiResponse();
    }

}