using Application.Common.Interfaces;
using Domain.Regions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Regions.Queries.GetRegions;

public sealed class GetRegionsQueryHandler(IAppDbContext context) : IRequestHandler<GetRegionsQuery, List<Region>>
{
    public async Task<List<Region>> Handle(GetRegionsQuery request, CancellationToken cancellationToken)
    {
        return await context.Regions.ToListAsync(cancellationToken);
    }
}
