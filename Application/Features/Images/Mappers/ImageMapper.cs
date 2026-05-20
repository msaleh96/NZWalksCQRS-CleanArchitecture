using Application.Features.Images.Dtos;
using Domain.Image;

namespace Application.Features.Images.Mappers;

public static class ImageMapper
{
    public static ImageDto ToDto(this Image entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new ImageDto
        {
            Id = entity.Id,
            path = entity.FilePath
        };
    }

    public static List<ImageDto> ToDtos(this IEnumerable<Image> entities)
    {
        ArgumentNullException.ThrowIfNull(entities);

        return entities.Select(e => e.ToDto()).ToList();
    }
}