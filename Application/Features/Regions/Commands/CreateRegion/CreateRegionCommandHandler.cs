
using Application.Common.Interfaces;
using Application.Features.Regions.Dtos;
using Application.Features.Regions.Mappers;
using Domain.Common.Results;
using Domain.Regions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Regions.Commands.CreateRegion;

public sealed class CreateRegionCommandHandler(IAppDbContext context): IRequestHandler<CreateRegionCommand, Result<RegionDto>>
{
    private readonly IAppDbContext _context = context;

    public async Task<Result<RegionDto>> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
    {
        var name = request.Name.Trim().ToLower();

        var existingRegion = await _context.Regions.AnyAsync(r => r.Name!.ToLower() == name, cancellationToken);

        if (existingRegion)
        {
            return RegionErrors.RegionAlreadyExists;
        }

        var region = Region.Create(request.Code, request.Name, request.imageUrl);

        if (region.IsError)
        {
            return region.Errors;
        }

        _context.Regions.Add(region.Value);
        await _context.SaveChangesAsync(cancellationToken);

        return region.Value.ToDto();
    }
}