using API.Common;
using Application.Features.Regions.Commands.CreateRegion;
using Application.Features.Regions.Commands.DeleteRegion;
using Application.Features.Regions.Commands.UpdateRegion;
using Application.Features.Regions.Dtos;
using Application.Features.Regions.Queries.GetRegions;
using Application.Features.Regions.Queries.GetRegionById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using API.Region.Requests;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegionsController(IMediator mediator)
    : BaseController<
        RegionDto,
        List<RegionDto>,
        GetRegionsQuery,
        GetRegionByIdQuery,
        CreateRegionRequest,
        CreateRegionCommand,
        UpdateRegionRequest,
        UpdateRegionCommand,
        DeleteRegionCommand
    >(mediator);