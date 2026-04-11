
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Walks;
using MediatR;

namespace Application.Walks.Commands.UpdateWalk;

public sealed class UpdateWalkCommandHandler(IAppDbContext context): IRequestHandler<UpdateWalkCommand>
{

    public async Task Handle(UpdateWalkCommand request, CancellationToken cancellationToken)
    {

        var walk = await context.Walks.FindAsync([request.Id], cancellationToken);
        
        if (walk is null)
            throw new NotFoundException(nameof(Walk), request.Id);

        walk.SetName(request.Name);
        walk.SetDescription(request.Description);
        walk.SetLength(request.LengthInKm);
        walk.UpdateDifficulty(request.DifficultyId);
        walk.UpdateRegion(request.RegionId);
        walk.SetImage(request.ImageUrl);

        await context.SaveChangesAsync(cancellationToken);
    }
}