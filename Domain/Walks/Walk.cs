using Domain.Common;
using Domain.Common.Results;
using Domain.Difficulties;
using Domain.Regions;

namespace Domain.Walks;

public class Walk : AuditableEntity
{
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public double LengthInKm { get; private set; } = default!;
    public string? WalkImageUrl { get; private set; }

    public Guid DifficultyId { get; private set; }
    public Guid RegionId { get; private set; }

    public Difficulty Difficulty { get; private set; } = default!;
    public Region Region { get; private set; } = default!;

    private Walk() { }

    private Walk(
        string name,
        string description,
        double lengthInKm,
        Guid difficultyId,
        Guid regionId,
        string? imageUrl = null)
    {
        SetName(name);
        SetDescription(description);
        SetLength(lengthInKm);

        DifficultyId = difficultyId;
        RegionId = regionId;

        WalkImageUrl = imageUrl;
    }


    public static Result<Walk> Create(        
        string name,
        string description,
        double lengthInKm,
        Guid difficultyId,
        Guid regionId,
        string? imageUrl = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            return WalkErrors.WalkNameIsRequired;

        if (string.IsNullOrWhiteSpace(description))
            return WalkErrors.WalkDescriptionIsRequired;

        if (lengthInKm <= 0)
            return WalkErrors.WalkLengthMustBePositive;

        if (difficultyId == Guid.Empty)
            return WalkErrors.WalkDifficultyIsRequired;

        if (regionId == Guid.Empty)
            return WalkErrors.WalkRegionIsRequired;

        return new Walk(name, description, lengthInKm, difficultyId, regionId, imageUrl);
    }


    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Walk name is required.");

        Name = name;
    }

    public void SetDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description is required.");

        Description = description;
    }

    public void SetLength(double lengthInKm)
    {
        if (lengthInKm <= 0)
            throw new ArgumentException("Length must be greater than zero.");

        LengthInKm = lengthInKm;
    }

    public void UpdateDifficulty(Guid difficultyId)
    {
        if (difficultyId == Guid.Empty)
            throw new ArgumentException("Invalid difficulty.");

        DifficultyId = difficultyId;
    }

    public void UpdateRegion(Guid regionId)
    {
        if (regionId == Guid.Empty)
            throw new ArgumentException("Invalid region.");

        RegionId = regionId;
    }

    public void SetImage(string? imageUrl)
    {
        WalkImageUrl = imageUrl;
    }
}