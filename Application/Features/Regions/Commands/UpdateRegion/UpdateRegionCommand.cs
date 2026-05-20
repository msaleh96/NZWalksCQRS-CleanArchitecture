using Application.Features.Regions.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Features.Regions.Commands.UpdateRegion;

public sealed record UpdateRegionCommand(Guid Id, string Code, string Name, string? image) : IRequest<Result<RegionDto>>;