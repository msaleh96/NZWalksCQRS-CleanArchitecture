using MediatR;

namespace Application.Walks.Commands.CreateWalk;

public sealed record CreateWalkCommand(
    string Name,
    string Description,
    double LengthInKm,
    Guid DifficultyId,
    Guid RegionId,
    string? ImageUrl) : IRequest<Guid>;