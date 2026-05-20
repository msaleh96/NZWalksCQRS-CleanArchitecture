using System.Text.Json.Serialization;

namespace API.Region.Requests;
public class UpdateRegionRequest
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;

    [JsonPropertyName("ImageUrl")]
    public string? Image { get; set; }
}