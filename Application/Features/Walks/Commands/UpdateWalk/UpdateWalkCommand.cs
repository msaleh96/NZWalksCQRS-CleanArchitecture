using Application.Features.Walks.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Features.Walks.Commands.UpdateWalk;

public sealed record UpdateWalkCommand(
    Guid Id,     
    string Name,
    string Description,
    double LengthInKm,
    Guid DifficultyId,
    Guid RegionId,
    string? ImageUrl) : IRequest<Result<WalkDto>> ;