using Application.Common.Interfaces;
using Application.Features.Difficulties.Dtos;
using Application.Features.Regions.Dtos;

namespace Application.Features.Walks.Dtos;

public class WalkDto : IHasId
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double LengthInKm { get; set; }
    public DifficultyDto? Difficulty { get; set; }
    public RegionDto? Region { get; set; }
    public string? ImageUrl { get; set; }
}