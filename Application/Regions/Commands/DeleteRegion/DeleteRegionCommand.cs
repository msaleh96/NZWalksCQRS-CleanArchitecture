using Application.Regions.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Regions.Commands.DeleteRegion;

public sealed record DeleteRegionCommand(Guid Id) : IRequest<Result<RegionDto>>;