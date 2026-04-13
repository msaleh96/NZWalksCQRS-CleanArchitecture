using Application.Common.Interfaces;
using Domain.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Common;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController<
    TDto,
    TListResponse,
    TListQuery,
    TGetByIdQuery,
    TCreateCommand,
    TUpdateCommand,
    TDeleteCommand
> : ControllerBase
    where TDto : IHasId
    where TListQuery : IRequest<Result<TListResponse>>
    where TGetByIdQuery : IRequest<Result<TDto?>>
    where TCreateCommand : IRequest<Result<TDto>>
    where TUpdateCommand : IRequest<Result<TDto>>
    where TDeleteCommand : IRequest<Result<TDto>>
{
    protected readonly IMediator _mediator;

    protected BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] TListQuery? query = default)
    {
        query ??= Activator.CreateInstance<TListQuery>();

        var result = await _mediator.Send(query);
        return result.ToApiResponse();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = (TGetByIdQuery)Activator.CreateInstance(typeof(TGetByIdQuery), id)!;

        var result = await _mediator.Send(query);
        return result.ToApiResponse();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TCreateCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.IsError)
            return result.ToApiResponse();

        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Value.Id },
            result.ToApiResponseBody()
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] TUpdateCommand command)
    {
        var prop = typeof(TUpdateCommand).GetProperty("Id");

        if (prop is not null)
            prop.SetValue(command, id);

        var result = await _mediator.Send(command);
        return result.ToApiResponse();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = (TDeleteCommand)Activator.CreateInstance(typeof(TDeleteCommand), id)!;

        var result = await _mediator.Send(command);
        return result.ToApiResponse();
    }
}