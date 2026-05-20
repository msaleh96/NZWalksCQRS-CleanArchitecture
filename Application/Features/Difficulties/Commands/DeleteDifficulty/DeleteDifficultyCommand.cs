using Application.Features.Difficulties.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Features.Difficulties.Commands.DeleteDifficulty;

public sealed record DeleteDifficultyCommand(Guid Id) : IRequest<Result<DifficultyDto>>;