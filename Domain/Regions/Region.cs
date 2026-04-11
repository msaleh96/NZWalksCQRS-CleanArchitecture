using Domain.Common;

namespace Domain.Regions;

public class Region : AuditableEntity
{
    public string Code { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public string? RegionImageUrl { get; private set; }

    private Region() { }

    private Region(string code, string name, string? imageUrl = null)
    {
        SetCode(code);
        SetName(name);
        SetImage(imageUrl);
    }

    public static Region Create(string code, string name, string? imageUrl = null)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Region code is required.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Region name is required.");

        return new Region(code, name, imageUrl);
    }

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