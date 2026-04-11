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
        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetDifficultyById")]
    public async Task<IActionResult> Get(Guid id)
    {
        var difficulty = await mediator.Send(new GetDifficultyByIdQuery(id));

        return difficulty is null ? NotFound() : Ok(difficulty);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateDifficultyRequest request)
    {
        var command = new CreateDifficultyCommand(request.Name);

        var id = await mediator.Send(command);

        return CreatedAtRoute("GetDifficultyById", new { id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateDifficultyRequest request)
    {        
        var command = new UpdateDifficultyCommand(id, request.Name); 

        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await mediator.Send(new DeleteDifficultyCommand(id));
        return NoContent();
    }

}