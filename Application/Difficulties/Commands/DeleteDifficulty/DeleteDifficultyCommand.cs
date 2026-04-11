using MediatR;

namespace Application.Difficulties.Commands.DeleteDifficulty;

public sealed record DeleteDifficultyCommand(Guid Id) : IRequest;