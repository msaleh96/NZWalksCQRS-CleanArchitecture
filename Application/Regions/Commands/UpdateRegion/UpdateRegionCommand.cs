using MediatR;

namespace Application.Regions.Commands.UpdateRegion;

public sealed record UpdateRegionCommand(Guid Id, string Code, string Name, string? image) : IRequest;