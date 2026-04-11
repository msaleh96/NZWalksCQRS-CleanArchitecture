using Application.Common.Interfaces;
using Application.Regions.Dtos;
using Application.Regions.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Regions.Queries.GetRegions;

public sealed class GetRegionsQueryHandler(IAppDbContext context) : IRequestHandler<GetRegionsQuery, List<RegionDto>>
{
    public async Task<List<RegionDto>> Handle(GetRegionsQuery request, CancellationToken cancellationToken)
    {
        var regions = await context.Regions.ToListAsync(cancellationToken);
        return regions.ToDtos();
    }
}
