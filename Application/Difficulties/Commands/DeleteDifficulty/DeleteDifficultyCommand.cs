using Application.Difficulties.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Difficulties.Commands.DeleteDifficulty;

public sealed record DeleteDifficultyCommand(Guid Id) : IRequest<Result<DifficultyDto>>;