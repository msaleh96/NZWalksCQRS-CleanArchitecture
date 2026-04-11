
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Difficulties;
using MediatR;

namespace Application.Difficulties.Commands.UpdateDifficulty;

public sealed class UpdateDifficultyCommandHandler(IAppDbContext context): IRequestHandler<UpdateDifficultyCommand>
{

    public async Task Handle(UpdateDifficultyCommand request, CancellationToken cancellationToken)
    {

        var difficulty = await context.Difficulties.FindAsync([request.Id], cancellationToken);
        
        if (difficulty is null)
            throw new NotFoundException(nameof(Difficulty), request.Id);

        difficulty.SetName(request.Name);

        await context.SaveChangesAsync(cancellationToken);
    }
}