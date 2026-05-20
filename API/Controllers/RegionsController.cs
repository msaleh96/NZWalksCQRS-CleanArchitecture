using API.Common;
using Application.Regions.Commands.CreateRegion;
using Application.Regions.Commands.DeleteRegion;
using Application.Regions.Commands.UpdateRegion;
using Application.Regions.Dtos;
using Application.Regions.Queries.GetRegions;
using Application.Regions.Queries.GetRegionById;
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