using API.Common;
using API.Difficulty.Requests;
using Application.Features.Difficulties.Commands.CreateDifficulty;
using Application.Features.Difficulties.Commands.DeleteDifficulty;
using Application.Features.Difficulties.Commands.UpdateDifficulty;
using Application.Features.Difficulties.Dtos;
using Application.Features.Difficulties.Queries.GetDifficulties;
using Application.Features.Difficulties.Queries.GetDifficultyById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DifficultiesController(IMediator mediator)
    : BaseController<
        DifficultyDto,
        List<DifficultyDto>,
        GetDifficultiesQuery,
        GetDifficultyByIdQuery,
        CreateDifficultyRequest,
        CreateDifficultyCommand,
        UpdateDifficultyRequest,
        UpdateDifficultyCommand,
        DeleteDifficultyCommand
    >(mediator);