
using Application.Common.Interfaces;
using Application.Features.Walks.Dtos;
using Application.Features.Walks.Mappers;
using Domain.Common.Results;
using Domain.Walks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Walks.Commands.CreateWalk;

public sealed class CreateWalkCommandHandler(IAppDbContext context): IRequestHandler<CreateWalkCommand, Result<WalkDto>>
{
    private readonly IAppDbContext _context = context;

    public async Task<Result<WalkDto>> Handle(CreateWalkCommand request, CancellationToken cancellationToken)
    {
        var difficultyExists = await _context.Difficulties
            .AnyAsync(d => d.Id == request.DifficultyId, cancellationToken);

        if (!difficultyExists)
            return WalkErrors.InvalidDifficulty;

        var regionExists = await _context.Regions
            .AnyAsync(r => r.Id == request.RegionId, cancellationToken);

        if (!regionExists)
            return WalkErrors.InvalidRegion;

        var walk = Walk.Create(
            request.Name,
            request.Description,
            request.LengthInKm,
            request.DifficultyId,
            request.RegionId,
            request.ImageUrl);

        if (walk.IsError)
            return walk.Errors;

        _context.Walks.Add(walk.Value);
        await _context.SaveChangesAsync(cancellationToken);

        return walk.Value.ToDto();
    }
}