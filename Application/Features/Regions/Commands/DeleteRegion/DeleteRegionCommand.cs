using Application.Features.Regions.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Features.Regions.Commands.DeleteRegion;

public sealed record DeleteRegionCommand(Guid Id) : IRequest<Result<RegionDto>>;