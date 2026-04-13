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
public class DifficultiesController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return await Send(new GetDifficultiesQuery());
    }

    [HttpGet("{id}", Name = "GetDifficultyById")]
    public async Task<IActionResult> Get(Guid id)
    {
        return await Send(new GetDifficultyByIdQuery(id));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateDifficultyRequest request)
    {
        return await SendCreate(
            new CreateDifficultyCommand(request.Name),
            "GetDifficultyById",
            x => new { id = x.Id }
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateDifficultyRequest request)
    {
        return await Send(new UpdateDifficultyCommand(id, request.Name));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return await Send(new DeleteDifficultyCommand(id));
    }

}