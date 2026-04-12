
using Application.Common.Interfaces;
using Application.Regions.Dtos;
using Application.Regions.Mappers;
using Domain.Common.Results;
using Domain.Regions;
using MediatR;

namespace Application.Regions.Commands.DeleteRegion;

public sealed class DeleteRegionCommandHandler(IAppDbContext context): IRequestHandler<DeleteRegionCommand, Result<RegionDto>>
{
    private readonly IAppDbContext _context = context;
    public async Task<Result<RegionDto>> Handle(DeleteRegionCommand request, CancellationToken cancellationToken)
    {

        var region = await _context.Regions.FindAsync([request.Id], cancellationToken);
        if (region is null)
            return RegionErrors.RegionNotFound;

        _context.Regions.Remove(region);

        await _context.SaveChangesAsync(cancellationToken);
        
        return region.ToDto();
    }
}