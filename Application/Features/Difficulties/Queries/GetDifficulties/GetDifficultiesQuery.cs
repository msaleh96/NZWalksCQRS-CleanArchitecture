using Application.Common.Interfaces;
using Application.Features.Difficulties.Dtos;
using Domain.Common.Results;
using MediatR;

namespace Application.Features.Difficulties.Queries.GetDifficulties;

public sealed record GetDifficultiesQuery : ICachedQuery<Result<List<DifficultyDto>>>
{
    public string CacheKey => "difficulties";

    public string[] Tags => ["difficulty"];

    public TimeSpan? Expiration => TimeSpan.FromMinutes(10);
}