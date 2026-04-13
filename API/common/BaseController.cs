using Domain.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Common;

[ApiController]
public abstract class BaseController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator _mediator = mediator;

    protected async Task<IActionResult> Send<T>(IRequest<Result<T>> request)
    {
        var result = await _mediator.Send(request);

        return result.ToApiResponse();
    }

    protected async Task<IActionResult> SendCreate<T>(
        IRequest<Result<T>> request,
        string routeName,
        Func<T, object> routeValues)
    {
        var result = await _mediator.Send(request);

        return result.ToCreatedResponse(routeName, routeValues);
    }
}