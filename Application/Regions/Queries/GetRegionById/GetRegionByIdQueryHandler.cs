using Application.Common.Interfaces;
using Application.Regions.Dtos;
using Application.Regions.Mappers;
using Domain.Common.Results;
using Domain.Regions;
using MediatR;

namespace Application.Regions.Queries.GetRegionById;

public sealed class GetRegionByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetRegionByIdQuery, Result<RegionDto?>>
{
    private readonly IAppDbContext _context = context;

    public async Task<Result<RegionDto?>> Handle(GetRegionByIdQuery request, CancellationToken cancellationToken)
    {
        var region = await _context.Regions.FindAsync([request.Id], cancellationToken);

        if (region is null)
            return RegionErrors.RegionNotFound;

        return region?.ToDto();
    }
}
