using Application.Regions.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Regions.Queries.GetRegions;

public sealed record GetRegionsQuery : IRequest<Result<List<RegionDto>>>;