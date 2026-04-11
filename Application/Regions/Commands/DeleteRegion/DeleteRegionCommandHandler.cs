
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Regions;
using MediatR;

namespace Application.Regions.Commands.DeleteRegion;

public sealed class DeleteRegionCommandHandler(IAppDbContext context): IRequestHandler<DeleteRegionCommand>
{

    public async Task Handle(DeleteRegionCommand request, CancellationToken cancellationToken)
    {

        var region = await context.Regions.FindAsync([request.Id], cancellationToken);
        if (region is null)
            throw new NotFoundException(nameof(Region), request.Id);

        context.Regions.Remove(region);

        await context.SaveChangesAsync(cancellationToken);
    }
}