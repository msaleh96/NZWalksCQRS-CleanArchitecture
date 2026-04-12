using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Domain.Walks;
using MediatR;
using Application.Walks.Dtos;
using Application.Walks.Mappers;
using Domain.Common.Results;

namespace Application.Walks.Queries.GetWalkById;

public sealed class GetWalkByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetWalkByIdQuery, Result<WalkDto?>>
{
    public async Task<Result<WalkDto?>> Handle(GetWalkByIdQuery request, CancellationToken cancellationToken)
    {
        var walk = await context.Walks
            .Include(w => w.Difficulty)
            .Include(w => w.Region)
            .FirstOrDefaultAsync(w => w.Id == request.Id, cancellationToken);

        if (walk is null)
            return WalkErrors.WalkNotFound;
            
        return walk?.ToDto();
    }
}
    