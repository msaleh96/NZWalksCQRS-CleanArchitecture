
using Application.Common.Interfaces;
using Domain.Regions;
using MediatR;

namespace Application.Regions.Commands.CreateRegion;

public sealed class CreateRegionCommandHandler(IAppDbContext context): IRequestHandler<CreateRegionCommand, Guid>
{

    public async Task<Guid> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
    {
        var region = Region.Create(request.Code, request.Name, request.imageUrl);

        context.Regions.Add(region);
        await context.SaveChangesAsync(cancellationToken);

        return region.Id;
    }
}