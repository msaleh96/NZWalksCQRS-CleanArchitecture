using Application.Regions.Dtos;
using MediatR;

namespace Application.Regions.Queries.GetRegions;

public sealed record GetRegionsQuery : IRequest<List<RegionDto>>;