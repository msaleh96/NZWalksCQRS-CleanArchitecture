using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Walks.Dtos;
using Application.Walks.Mappers;
using Domain.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Walks.Queries.GetWalks;

public sealed class GetWalksQueryHandler(IAppDbContext context)
    : IRequestHandler<GetWalksQuery, Result<PagedResult<WalkDto>>>
{
    public async Task<Result<PagedResult<WalkDto>>> Handle(GetWalksQuery request, CancellationToken cancellationToken)
    {
        var query = context.Walks
            .Include(w => w.Difficulty)
            .Include(w => w.Region)
            .AsQueryable();

        var totalCount = await query.CountAsync(cancellationToken);

        var walks = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var result = new PagedResult<WalkDto>
        {
            Items = walks.ToDtos(),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };

        return result;
    }
}