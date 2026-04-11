using MediatR;

namespace Application.Regions.Commands.DeleteRegion;

public sealed record DeleteRegionCommand(Guid Id) : IRequest;