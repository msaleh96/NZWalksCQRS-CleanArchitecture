using Application.Regions.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Regions.Queries.GetRegionById;

public sealed record GetRegionByIdQuery(Guid Id) : IRequest<Result<RegionDto?>>;