using Application.Common.Interfaces;
using Domain.Regions;
using MediatR;

namespace Application.Regions.Queries.GetRegionById;

public sealed class GetRegionByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetRegionByIdQuery, Region?>
{
    public async Task<Region?> Handle(GetRegionByIdQuery request, CancellationToken cancellationToken)
    {
        return await context.Regions.FindAsync([request.Id], cancellationToken);
    }
}
