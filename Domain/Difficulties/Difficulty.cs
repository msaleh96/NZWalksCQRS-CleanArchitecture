using Domain.Common;

namespace Domain.Difficulties;

public class Difficulty : AuditableEntity
{
    public string Name { get; private set; } = default!;

    private Difficulty() { }

    private Difficulty(string name)
    {
        Name = name;
    }

    public static Difficulty Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Difficulty name cannot be empty.");

        return new Difficulty(name);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Difficulty name cannot be empty.");

        Name = name;
    }
}