
using Application.Common.Interfaces;
using Domain.Difficulties;
using MediatR;

namespace Application.Difficulties.Commands.CreateDifficulty;

public sealed class CreateDifficultyCommandHandler(IAppDbContext context): IRequestHandler<CreateDifficultyCommand, Guid>
{

    public async Task<Guid> Handle(CreateDifficultyCommand request, CancellationToken cancellationToken)
    {
        var difficulty = new Difficulty(request.Name);

        context.Difficulties.Add(difficulty);
        await context.SaveChangesAsync(cancellationToken);

        return difficulty.Id;
    }
}