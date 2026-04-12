using Application.Walks.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Walks.Commands.DeleteWalk;

public sealed record DeleteWalkCommand(Guid Id) : IRequest<Result<WalkDto>>;