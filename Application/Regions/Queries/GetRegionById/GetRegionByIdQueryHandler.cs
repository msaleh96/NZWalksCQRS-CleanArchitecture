using Application.Common.Interfaces;
using Application.Regions.Dtos;
using Application.Regions.Mappers;
using MediatR;

namespace Application.Regions.Queries.GetRegionById;

public sealed class GetRegionByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetRegionByIdQuery, RegionDto?>
{
    public async Task<RegionDto?> Handle(GetRegionByIdQuery request, CancellationToken cancellationToken)
    {
        var region = await context.Regions.FindAsync([request.Id], cancellationToken);
        return region?.ToDto();
    }
}
