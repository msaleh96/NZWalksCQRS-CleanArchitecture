using Application.Common.Interfaces;
using Application.Walks.Dtos;
using Application.Walks.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Walks.Queries.GetWalks;

public sealed class GetWalksQueryHandler(IAppDbContext context) : IRequestHandler<GetWalksQuery, List<WalkDto>>
{
    public async Task<List<WalkDto>> Handle(GetWalksQuery request, CancellationToken cancellationToken)
    {
        var walks = await context.Walks.Include(w => w.Difficulty).Include(w => w.Region).ToListAsync(cancellationToken);
        return walks.ToDtos();
    }
}
