using Domain.Walks;
using Application.Walks.Dtos;
using Application.Difficulties.Mappers;
using Application.Regions.Mappers;

namespace Application.Walks.Mappers;

public static class WalkMapper
{
    public static WalkDto ToDto(this Walk entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new WalkDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            LengthInKm = entity.LengthInKm,
            Difficulty = entity.Difficulty?.ToDto(),
            Region = entity.Region?.ToDto(),
            ImageUrl = entity.WalkImageUrl
        };
    }

    public static List<WalkDto> ToDtos(this IEnumerable<Walk> entities)
    {
        ArgumentNullException.ThrowIfNull(entities);

        return entities.Select(e => e.ToDto()).ToList();
    }
}