using Application.Features.Difficulties.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Features.Difficulties.Commands.CreateDifficulty;

public sealed record CreateDifficultyCommand(string Name) : IRequest<Result<DifficultyDto>>;