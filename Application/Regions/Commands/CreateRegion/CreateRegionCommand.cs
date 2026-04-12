using Application.Regions.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Regions.Commands.CreateRegion;

public sealed record CreateRegionCommand(string Code, string Name, string? imageUrl) : IRequest<Result<RegionDto>>;