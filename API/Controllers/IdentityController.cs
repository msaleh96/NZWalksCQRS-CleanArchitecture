using System.Security.Claims;

using Application.Features.Identity.Queries.GenerateTokens;
using Application.Features.Identity.Queries.GetUserInfo;
using Application.Features.Identity.Queries.RefreshTokens;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Identity.Commands.RegisterUser;
using API.Common;

namespace Api.Controllers;

[Route("identity")]
[ApiController]
public sealed class IdentityController(ISender sender) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> GenerateToken([FromBody] GenerateTokenQuery request, CancellationToken ct)
    {
        var result = await sender.Send(request, ct);
        return result.ToApiResponse();
    }

    [HttpPost("token/refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenQuery request, CancellationToken ct)
    {
        var result = await sender.Send(request, ct);

        return result.ToApiResponse();
    }

    [HttpGet("current-user/claims")]
    [Authorize]
    public async Task<IActionResult> GetCurrentUserInfo(CancellationToken ct)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var result = await sender.Send(new GetUserByIdQuery(userId), ct);
        return result.ToApiResponse();  
    }

    [HttpPost("signup")]
    public async Task<IActionResult> Signup(
        [FromBody] RegisterUserCommand request,
        CancellationToken ct)
    {
        var result = await sender.Send(request, ct);

        return result.ToApiResponse();
    }
}