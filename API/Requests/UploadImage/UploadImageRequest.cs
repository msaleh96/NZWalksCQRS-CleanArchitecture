namespace API.Requests.UploadImage;

public class UploadImageRequest
{
    public IFormFile File { get; set; } = default!;

    public string Description { get; set; } = string.Empty;
}