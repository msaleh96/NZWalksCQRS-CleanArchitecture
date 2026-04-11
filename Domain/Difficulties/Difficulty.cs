namespace Domain.Difficulties;

public class Difficulty
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = default!;

    public Difficulty(string name)
    {
        SetName(name);
    }

    private Difficulty() { }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Difficulty name cannot be empty.");

        Name = name;
    }
}