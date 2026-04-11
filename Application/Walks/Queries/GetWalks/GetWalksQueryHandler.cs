using Application.Common.Interfaces;
using Domain.Walks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Walks.Queries.GetWalks;

public sealed class GetWalksQueryHandler(IAppDbContext context) : IRequestHandler<GetWalksQuery, List<Walk>>
{
    public async Task<List<Walk>> Handle(GetWalksQuery request, CancellationToken cancellationToken)
    {
        return await context.Walks.Include(w => w.Difficulty).Include(w => w.Region).ToListAsync(cancellationToken);
    }
}
