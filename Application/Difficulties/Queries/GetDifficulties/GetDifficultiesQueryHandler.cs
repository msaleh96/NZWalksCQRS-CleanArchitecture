using Application.Common.Interfaces;
using Application.Difficulties.Dtos;
using Application.Difficulties.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Difficulties.Queries.GetDifficulties;

public sealed class GetDifficultiesQueryHandler(IAppDbContext context) : IRequestHandler<GetDifficultiesQuery, List<DifficultyDto>>
{
    public async Task<List<DifficultyDto>> Handle(GetDifficultiesQuery request, CancellationToken cancellationToken)
    {
        var difficulties = await context.Difficulties.ToListAsync(cancellationToken);
        return difficulties.ToDtos();
    }
}
