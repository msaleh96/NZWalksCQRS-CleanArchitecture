using MediatR;

namespace Application.Difficulties.Commands.CreateDifficulty;

public sealed record CreateDifficultyCommand(string Name) : IRequest<Guid>;