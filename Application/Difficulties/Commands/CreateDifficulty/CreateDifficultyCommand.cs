using Application.Difficulties.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Difficulties.Commands.CreateDifficulty;

public sealed record CreateDifficultyCommand(string Name) : IRequest<Result<DifficultyDto>>;