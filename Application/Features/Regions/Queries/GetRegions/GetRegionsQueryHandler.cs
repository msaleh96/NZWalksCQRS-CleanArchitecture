using Application.Common.Interfaces;
using Application .Features.Regions.Dtos;
using Application.Features.Regions.Mappers;
using Domain.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Regions.Queries.GetRegions;

public sealed class GetRegionsQueryHandler(IAppDbContext context) : IRequestHandler<GetRegionsQuery, Result<List<RegionDto>>>
{
    private readonly IAppDbContext _context = context;
    public async Task<Result<List<RegionDto>>> Handle(GetRegionsQuery request, CancellationToken cancellationToken)
    {
        var regions = await _context.Regions.ToListAsync(cancellationToken);
        return regions.ToDtos();
    }
}
