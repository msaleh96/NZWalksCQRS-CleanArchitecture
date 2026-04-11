
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Difficulties;
using MediatR;

namespace Application.Difficulties.Commands.DeleteDifficulty;

public sealed class DeleteDifficultyCommandHandler(IAppDbContext context): IRequestHandler<DeleteDifficultyCommand>
{

    public async Task Handle(DeleteDifficultyCommand request, CancellationToken cancellationToken)
    {

        var difficulty = await context.Difficulties.FindAsync([request.Id], cancellationToken);
        if (difficulty is null)
            throw new NotFoundException(nameof(Difficulty), request.Id);

        context.Difficulties.Remove(difficulty);

        await context.SaveChangesAsync(cancellationToken);
    }
}