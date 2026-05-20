namespace Application.Features.Images.Dtos;

public class ImageDto
{
    public Guid Id { get; set; }
    public string path { get; set; } = default!;
}