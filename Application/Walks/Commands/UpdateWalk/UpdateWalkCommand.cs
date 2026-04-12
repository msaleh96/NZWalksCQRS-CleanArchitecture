using Application.Walks.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Walks.Commands.UpdateWalk;

public sealed record UpdateWalkCommand(
    Guid Id,     
    string Name,
    string Description,
    double LengthInKm,
    Guid DifficultyId,
    Guid RegionId,
    string? ImageUrl) : IRequest<Result<WalkDto>> ;