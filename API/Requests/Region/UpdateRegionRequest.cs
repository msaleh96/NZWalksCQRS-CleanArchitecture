namespace API.Region.Requests;
public class UpdateRegionRequest
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string? imageUrl { get; set; }
}