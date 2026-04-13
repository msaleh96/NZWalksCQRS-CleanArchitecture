using API.Walk.Requests;
using Application.Walks.Commands.CreateWalk;
using Application.Walks.Commands.DeleteWalk;
using Application.Walks.Commands.UpdateWalk;
using Application.Walks.Queries.GetWalks;
using Application.Walks.Queries.GetWalkById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using API.Common;
using Application.Walks.Dtos;
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
        CreateWalkCommand,
        UpdateWalkCommand,
        DeleteWalkCommand
    >(mediator);