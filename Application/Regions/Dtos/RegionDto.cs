namespace Application.Regions.Dtos;

public class RegionDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
}