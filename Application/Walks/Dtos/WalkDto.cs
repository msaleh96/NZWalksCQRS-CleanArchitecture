using Application.Difficulties.Dtos;
using Application.Regions.Dtos;
using Domain.Difficulties;
using Domain.Regions;

namespace Application.Walks.Dtos;

public class WalkDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double LengthInKm { get; set; }
    public DifficultyDto? Difficulty { get; set; }
    public RegionDto? Region { get; set; }
    public string? ImageUrl { get; set; }
}