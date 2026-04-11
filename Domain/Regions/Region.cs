namespace Domain.Regions;

public class Region
{
    public Guid Id { get; private set; }
    public string Code { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public string? RegionImageUrl { get; private set; }

    public Region(string code, string name, string? imageUrl = null)
    {
        SetCode(code);
        SetName(name);
        SetImage(imageUrl);
    }

    private Region() { }

    public void SetCode(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Region code is required.");

        Code = code;
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Region name is required.");

        Name = name;
    }

    public void SetImage(string? imageUrl)
    {
        RegionImageUrl = imageUrl;
    }
}