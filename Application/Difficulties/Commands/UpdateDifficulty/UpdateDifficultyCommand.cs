using MediatR;

namespace Application.Difficulties.Commands.UpdateDifficulty;

public sealed record UpdateDifficultyCommand(Guid Id, string Name) : IRequest;