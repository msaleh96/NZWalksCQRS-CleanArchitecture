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
public class RegionsController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return await Send(new GetRegionsQuery());
    }

    [HttpGet("{id}", Name = "GetRegionById")]
    public async Task<IActionResult> Get(Guid id)
    {
        return await Send(new GetRegionByIdQuery(id));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateRegionRequest request)
    {
        var command = new CreateRegionCommand(request.Code, request.Name, request.imageUrl);

        return await SendCreate(
            command,
            "GetRegionById",
            x => new { id = x.Id }
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateRegionRequest request)
    {        
        var command = new UpdateRegionCommand(id, request.Code, request.Name, request.imageUrl); 

        return await Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return await Send(new DeleteRegionCommand(id));
    }

}