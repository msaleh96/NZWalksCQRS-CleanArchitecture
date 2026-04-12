using Domain.Common.Results;

namespace Domain.Walks;

public static class WalkErrors
{
    public static Error WalkNameIsRequired => Error.Validation(
        code: "Walk.NameRequired",
        description: "Walk name is required."
    );

    public static Error WalkDescriptionIsRequired => Error.Validation(
        code: "Walk.DescriptionRequired",
        description: "Walk description is required."
    );

    public static Error WalkLengthMustBePositive => Error.Validation(
        code: "Walk.LengthMustBePositive",
        description: "Walk length must be greater than zero."
    );

    public static Error WalkDifficultyIsRequired => Error.Validation(
        code: "Walk.DifficultyRequired",
        description: "Walk difficulty is required."
    );
    
    public static Error WalkRegionIsRequired => Error.Validation(
        code: "Walk.RegionRequired",
        description: "Walk region is required."
    );

    public static Error InvalidDifficulty => Error.Validation(
        code: "Walk.InvalidDifficulty",
        description: "Difficulty Not Found."
    );

    public static Error InvalidRegion => Error.Validation(
        code: "Walk.InvalidRegion",
        description: "Region Not Found."
    );

    public static Error WalkNotFound => Error.NotFound(
        code: "Walk.NotFound",
        description: "Walk not found."
    );
}