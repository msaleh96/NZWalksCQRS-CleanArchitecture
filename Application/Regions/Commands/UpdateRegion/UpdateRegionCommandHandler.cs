
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Regions;
using MediatR;

namespace Application.Regions.Commands.UpdateRegion;

public sealed class UpdateRegionCommandHandler(IAppDbContext context): IRequestHandler<UpdateRegionCommand>
{

    public async Task Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
    {

        var region = await context.Regions.FindAsync([request.Id], cancellationToken);
        
        if (region is null)
            throw new NotFoundException(nameof(Region), request.Id);

        region.SetCode(request.Code);
        region.SetName(request.Name);
        region.SetImage(request.image);

        await context.SaveChangesAsync(cancellationToken);
    }
}