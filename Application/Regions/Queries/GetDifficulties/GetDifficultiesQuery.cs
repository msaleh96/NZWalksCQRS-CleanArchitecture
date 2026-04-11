using Domain.Regions;
using MediatR;

namespace Application.Regions.Queries.GetRegions;

public sealed record GetRegionsQuery : IRequest<List<Region>>;