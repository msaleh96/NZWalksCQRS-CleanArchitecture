using Application.Common.Interfaces;
using Application.Features.Difficulties.Dtos;
using Application.Features.Difficulties.Mappers;
using Domain.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Difficulties.Queries.GetDifficulties;

public sealed class GetDifficultiesQueryHandler(IAppDbContext context) : IRequestHandler<GetDifficultiesQuery, Result<List<DifficultyDto>>>
{
    private readonly IAppDbContext _context = context;
    public async Task<Result<List<DifficultyDto>>> Handle(GetDifficultiesQuery request, CancellationToken cancellationToken)
    {
        var difficulties = await _context.Difficulties.ToListAsync(cancellationToken);
        return difficulties.ToDtos();
    }
}
