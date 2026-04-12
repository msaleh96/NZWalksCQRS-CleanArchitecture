
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Walks.Dtos;
using Application.Walks.Mappers;
using Domain.Common.Results;
using Domain.Walks;
using MediatR;

namespace Application.Walks.Commands.UpdateWalk;

public sealed class UpdateWalkCommandHandler(IAppDbContext context): IRequestHandler<UpdateWalkCommand, Result<WalkDto>>
{
    private readonly IAppDbContext _context = context;

    public async Task<Result<WalkDto>> Handle(UpdateWalkCommand request, CancellationToken cancellationToken)
    {

        var walk = await _context.Walks.FindAsync([request.Id], cancellationToken);
        
        if (walk is null)
            return WalkErrors.WalkNotFound;

        walk.SetName(request.Name);
        walk.SetDescription(request.Description);
        walk.SetLength(request.LengthInKm);
        walk.UpdateDifficulty(request.DifficultyId);
        walk.UpdateRegion(request.RegionId);
        walk.SetImage(request.ImageUrl);

        await _context.SaveChangesAsync(cancellationToken);
        
        return walk.ToDto();
    }
}