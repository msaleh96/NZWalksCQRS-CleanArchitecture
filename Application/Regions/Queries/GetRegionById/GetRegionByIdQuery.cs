using Application.Regions.Dtos;
using MediatR;

namespace Application.Regions.Queries.GetRegionById;

public sealed record GetRegionByIdQuery(Guid Id) : IRequest<RegionDto?>;