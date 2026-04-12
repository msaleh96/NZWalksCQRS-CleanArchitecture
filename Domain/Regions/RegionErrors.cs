using Domain.Common.Results;

namespace Domain.Regions;

public static class RegionErrors
{
    public static Error RegionNameIsRequired => Error.Validation(
        code: "Region.NameRequired",
        description: "Region name is required."
    );

    public static Error RegionCodeIsRequired => Error.Validation(
        code: "Region.CodeRequired",
        description: "Region code is required."
    );

    public static Error RegionAlreadyExists => Error.Validation(
        code: "Region.AlreadyExists",
        description: "A region with the same name already exists."
    );

    public static Error RegionNotFound => Error.NotFound(
        code: "Region.NotFound",
        description: "Region not found."
    );
}