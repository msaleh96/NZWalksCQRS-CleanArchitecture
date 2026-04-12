using Domain.Common.Results;

namespace Domain.Difficulties;

public static class DifficultyErrors
{
    public static Error DifficultyNameIsRequired => Error.Validation(
        code: "Difficulty.NameRequired",
        description: "Difficulty name is required."
    );

    public static Error DifficultyAlreadyExists => Error.Validation(
        code: "Difficulty.AlreadyExists",
        description: "A difficulty with the same name already exists."
    );

    public static Error DifficultyNotFound => Error.NotFound(
        code: "Difficulty.NotFound",
        description: "Difficulty not found."
    );
}