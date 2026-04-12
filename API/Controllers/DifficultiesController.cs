using API.Common;
using API.Difficulty.Requests;
using Application.Difficulties.Commands.CreateDifficulty;
using Application.Difficulties.Commands.DeleteDifficulty;
using Application.Difficulties.Commands.UpdateDifficulty;
using Application.Difficulties.Queries.GetDifficulties;
using Application.Difficulties.Queries.GetDifficultyById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DifficultiesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await mediator.Send(new GetDifficultiesQuery());
        return result.ToApiResponse();
    }

    [HttpGet("{id}", Name = "GetDifficultyById")]
    public async Task<IActionResult> Get(Guid id)
    {
        var difficulty = await mediator.Send(new GetDifficultyByIdQuery(id));

        return difficulty.ToApiResponse();
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateDifficultyRequest request)
    {
        var command = new CreateDifficultyCommand(request.Name);

        var result = await mediator.Send(command);

        return result.ToCreatedResponse(
            "GetDifficultyById",
            x => new { id = x.Id }
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateDifficultyRequest request)
    {        
        var command = new UpdateDifficultyCommand(id, request.Name); 

        var result = await mediator.Send(command);
        return result.ToApiResponse();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteDifficultyCommand(id));
        return result.ToApiResponse();
    }

}