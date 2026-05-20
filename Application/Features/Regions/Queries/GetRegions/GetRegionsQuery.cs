using Application.Features.Regions.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Features.Regions.Queries.GetRegions;

public sealed record GetRegionsQuery : IRequest<Result<List<RegionDto>>>;