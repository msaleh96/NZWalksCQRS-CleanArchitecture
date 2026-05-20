using API.Walk.Requests;
using Application.Features.Walks.Commands.CreateWalk;
using Application.Features.Walks.Commands.DeleteWalk;
using Application.Features.Walks.Commands.UpdateWalk;
using Application.Features.Walks.Queries.GetWalks;
using Application.Features.Walks.Queries.GetWalkById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using API.Common;
using Application.Features.Walks.Dtos;
using Application.Common.Models;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WalksController(IMediator mediator)
    : BaseController<
        WalkDto,
        PagedResult<WalkDto>,
        GetWalksQuery,
        GetWalkByIdQuery,
        CreateWalkRequest,
        CreateWalkCommand,
        UpdateWalkRequest,
        UpdateWalkCommand,
        DeleteWalkCommand
    >(mediator);