using API.Common;
using API.Difficulty.Requests;
using Application.Difficulties.Commands.CreateDifficulty;
using Application.Difficulties.Commands.DeleteDifficulty;
using Application.Difficulties.Commands.UpdateDifficulty;
using Application.Difficulties.Dtos;
using Application.Difficulties.Queries.GetDifficulties;
using Application.Difficulties.Queries.GetDifficultyById;
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