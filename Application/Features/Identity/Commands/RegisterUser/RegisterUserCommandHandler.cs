using Application.Common.Interfaces;
using Application.Features.Identity.Dtos;

using Domain.Common.Results;

using MediatR;

namespace Application.Features.Identity.Commands.RegisterUser;

public sealed class RegisterUserCommandHandler(
    IIdentityService identityService)
    : IRequestHandler<RegisterUserCommand, Result<AppUserDto>>
{
    public async Task<Result<AppUserDto>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        return await identityService.RegisterAsync(
            request.Email,
            request.Password);
    }
}