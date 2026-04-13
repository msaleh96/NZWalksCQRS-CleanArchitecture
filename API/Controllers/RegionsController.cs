using API.Common;
using Application.Regions.Commands.CreateRegion;
using Application.Regions.Commands.DeleteRegion;
using Application.Regions.Commands.UpdateRegion;
using Application.Regions.Dtos;
using Application.Regions.Queries.GetRegions;
using Application.Regions.Queries.GetRegionById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegionsController(IMediator mediator)
    : BaseController<
        RegionDto,
        List<RegionDto>,
        GetRegionsQuery,
        GetRegionByIdQuery,
        CreateRegionCommand,
        UpdateRegionCommand,
        DeleteRegionCommand
    >(mediator);