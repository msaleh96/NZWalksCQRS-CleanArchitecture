using Application.Features.Difficulties.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Features.Difficulties.Commands.UpdateDifficulty;

public sealed record UpdateDifficultyCommand(Guid Id, string Name) : IRequest<Result<DifficultyDto>>;