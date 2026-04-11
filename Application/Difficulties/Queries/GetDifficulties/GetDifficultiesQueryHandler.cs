using Application.Common.Interfaces;
using Domain.Difficulties;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Difficulties.Queries.GetDifficulties;

public sealed class GetDifficultiesQueryHandler(IAppDbContext context) : IRequestHandler<GetDifficultiesQuery, List<Difficulty>>
{
    public async Task<List<Difficulty>> Handle(GetDifficultiesQuery request, CancellationToken cancellationToken)
    {
        return await context.Difficulties.ToListAsync(cancellationToken);
    }
}
