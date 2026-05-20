using Application.Common.Interfaces;

namespace Application.Features.Regions.Dtos;

public class RegionDto : IHasId
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
}