
using Application.Common.Interfaces;
using Domain.Walks;
using MediatR;

namespace Application.Walks.Commands.CreateWalk;

public sealed class CreateWalkCommandHandler(IAppDbContext context): IRequestHandler<CreateWalkCommand, Guid>
{

    public async Task<Guid> Handle(CreateWalkCommand request, CancellationToken cancellationToken)
    {
        var walk = new Walk(request.Name, request.Description, request.LengthInKm, request.DifficultyId, request.RegionId, request.ImageUrl);

        context.Walks.Add(walk);
        await context.SaveChangesAsync(cancellationToken);

        return walk.Id;
    }
}