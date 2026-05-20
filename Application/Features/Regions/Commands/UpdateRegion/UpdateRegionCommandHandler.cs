
using Application.Common.Interfaces;
using Application.Features.Regions.Dtos;
using Application.Features.Regions.Mappers;
using Domain.Common.Results;
using Domain.Regions;
using MediatR;

namespace Application.Features.Regions.Commands.UpdateRegion;

public sealed class UpdateRegionCommandHandler(IAppDbContext context): IRequestHandler<UpdateRegionCommand, Result<RegionDto>>
{
    private readonly IAppDbContext _context = context;

    public async Task<Result<RegionDto>> Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
    {

        var region = await _context.Regions.FindAsync([request.Id], cancellationToken);
        
        if (region is null)
            return RegionErrors.RegionNotFound;

        region.SetCode(request.Code);
        region.SetName(request.Name);
        region.SetImage(request.image);

        await _context.SaveChangesAsync(cancellationToken);

        return region.ToDto();
    }
}