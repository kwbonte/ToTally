namespace ToTally.Domain.Leagues;

public class League
{
    public int Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Abbreviation { get; private set; } = string.Empty;

    private League()
    {
        // Required by EF Core
    }

    public League(string name, string abbreviation)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("League name is required.", nameof(name));
        }

        if (string.IsNullOrWhiteSpace(abbreviation))
        {
            throw new ArgumentException("League abbreviation is required.", nameof(abbreviation));
        }

        Name = name.Trim();
        Abbreviation = abbreviation.Trim().ToUpperInvariant();
    }
}