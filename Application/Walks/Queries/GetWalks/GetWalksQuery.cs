using Application.Common.Models;
using Application.Walks.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Walks.Queries.GetWalks;

public sealed record GetWalksQuery(
    int PageNumber = 1,
    int PageSize = 10
) : IRequest<Result<PagedResult<WalkDto>>>;