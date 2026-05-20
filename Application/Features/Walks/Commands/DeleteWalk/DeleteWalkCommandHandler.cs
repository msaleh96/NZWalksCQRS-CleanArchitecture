
using Application.Common.Interfaces;
using Application.Features.Walks.Dtos;
using Application.Features.Walks.Mappers;
using Domain.Common.Results;
using Domain.Walks;
using MediatR;

namespace Application.Features.Walks.Commands.DeleteWalk;

public sealed class DeleteWalkCommandHandler(IAppDbContext context): IRequestHandler<DeleteWalkCommand, Result<WalkDto>>
{
    private readonly IAppDbContext _context = context;

    public async Task<Result<WalkDto>> Handle(DeleteWalkCommand request, CancellationToken cancellationToken)
    {

        var walk = await _context.Walks.FindAsync([request.Id], cancellationToken);
        if (walk is null)
            return WalkErrors.WalkNotFound;

        _context.Walks.Remove(walk);

        await _context.SaveChangesAsync(cancellationToken);
        return walk.ToDto();
    }
}