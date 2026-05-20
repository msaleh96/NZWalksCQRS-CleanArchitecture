using Application.Features.Difficulties.Dtos;
using Domain.Difficulties;

namespace Application.Features.Difficulties.Mappers;

public static class DifficultyMapper
{
    public static DifficultyDto ToDto(this Difficulty entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new DifficultyDto
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }

    public static List<DifficultyDto> ToDtos(this IEnumerable<Difficulty> entities)
    {
        ArgumentNullException.ThrowIfNull(entities);

        return entities.Select(e => e.ToDto()).ToList();
    }
}