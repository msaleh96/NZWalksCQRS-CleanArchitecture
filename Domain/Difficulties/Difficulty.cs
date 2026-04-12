using Domain.Common;
using Domain.Common.Results;

namespace Domain.Difficulties;

public class Difficulty : AuditableEntity
{
    public string Name { get; private set; } = default!;

    private Difficulty() { }

    private Difficulty(string name)
    {
        Name = name;
    }

    public static Result<Difficulty> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return DifficultyErrors.DifficultyNameIsRequired;

        return new Difficulty(name);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Difficulty name cannot be empty.");

        Name = name;
    }
}