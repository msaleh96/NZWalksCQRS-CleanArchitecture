using Application.Regions.Dtos;
using Domain.Regions;

namespace Application.Regions.Mappers;

public static class RegionMapper
{
    public static RegionDto ToDto(this Region entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new RegionDto
        {
            Id = entity.Id,
            Name = entity.Name,
            ImageUrl = entity.RegionImageUrl
        };
    }

    public static List<RegionDto> ToDtos(this IEnumerable<Region> entities)
    {
        ArgumentNullException.ThrowIfNull(entities);

        return entities.Select(e => e.ToDto()).ToList();
    }
}