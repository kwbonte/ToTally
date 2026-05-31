using ToTally.Domain.Common;

namespace ToTally.Domain.Leagues;

public class League : EntityBase
{
    public int Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Abbreviation { get; private set; } = string.Empty;

    public string Sport { get; private set; } = string.Empty;

    private League()
    {
        // Required by EF Core
    }

    public League(string name, string abbreviation, string sport)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("League name is required.", nameof(name));
        }

        if (string.IsNullOrWhiteSpace(abbreviation))
        {
            throw new ArgumentException("League abbreviation is required.", nameof(abbreviation));
        }

        if (string.IsNullOrWhiteSpace(sport))
        {
            throw new ArgumentException("Sport is required.", nameof(sport));
        }
        Name = name.Trim();
        Abbreviation = abbreviation.Trim().ToUpperInvariant();
        Sport = sport.Trim();
    }
}