using Application.Common.Interfaces;
using Application.Difficulties.Dtos;
using Application.Regions.Dtos;

namespace Application.Walks.Dtos;

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