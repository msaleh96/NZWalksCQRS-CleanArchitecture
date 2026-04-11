namespace API.Walk.Requests;
public class UpdateWalkRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double LengthInKm { get; set; } = 0;
    public Guid DifficultyId { get; set; } = Guid.Empty;
    public Guid RegionId { get; set; } = Guid.Empty;
    public string? imageUrl { get; set; }
}