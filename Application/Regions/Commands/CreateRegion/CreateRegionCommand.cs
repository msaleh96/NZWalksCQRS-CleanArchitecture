using MediatR;

namespace Application.Regions.Commands.CreateRegion;

public sealed record CreateRegionCommand(string Code, string Name, string? image) : IRequest<Guid>;