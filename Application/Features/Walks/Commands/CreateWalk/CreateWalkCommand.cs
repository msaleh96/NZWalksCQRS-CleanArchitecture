using Application.Features.Walks.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Features.Walks.Commands.CreateWalk;

public sealed record CreateWalkCommand(
    string Name,
    string Description,
    double LengthInKm,
    Guid DifficultyId,
    Guid RegionId,
    string? ImageUrl) : IRequest<Result<WalkDto>>;