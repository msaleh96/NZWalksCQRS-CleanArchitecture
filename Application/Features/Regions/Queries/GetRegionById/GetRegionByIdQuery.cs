using Application.Features.Regions.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Features.Regions.Queries.GetRegionById;

public sealed record GetRegionByIdQuery(Guid Id) : IRequest<Result<RegionDto?>>;