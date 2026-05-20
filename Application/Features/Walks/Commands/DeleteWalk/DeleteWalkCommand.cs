using Application.Features.Walks.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Features.Walks.Commands.DeleteWalk;

public sealed record DeleteWalkCommand(Guid Id) : IRequest<Result<WalkDto>>;