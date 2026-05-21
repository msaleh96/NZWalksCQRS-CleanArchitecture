using Application.Features.Identity.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Features.Identity.Commands.RegisterUser;

public sealed record RegisterUserCommand(string Email, string Password) : IRequest<Result<AppUserDto>>;