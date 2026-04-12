using Application.Common.Interfaces;
using Application.Regions.Dtos;
using Application.Regions.Mappers;
using Domain.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Regions.Queries.GetRegions;

public sealed class GetRegionsQueryHandler(IAppDbContext context) : IRequestHandler<GetRegionsQuery, Result<List<RegionDto>>>
{
    private readonly IAppDbContext _context = context;
    public async Task<Result<List<RegionDto>>> Handle(GetRegionsQuery request, CancellationToken cancellationToken)
    {
        var regions = await _context.Regions.ToListAsync(cancellationToken);
        return regions.ToDtos();
    }
}
