using ToTally.Domain.Common;
using ToTally.Domain.Divisions;
using ToTally.Domain.Leagues;

namespace ToTally.Domain.Conferences;

public class Conference : EntityBase
{
    public int Id { get; private set; }

    public int LeagueId { get; private set; }
    public League League { get; private set; } = null!;

    public string Name { get; private set; } = string.Empty;
    public string Abbreviation { get; private set; } = string.Empty;

    private readonly List<Division> _divisions = new();
    public IReadOnlyCollection<Division> Divisions => _divisions.AsReadOnly();

    private Conference()
    {
    }

    public Conference(int leagueId, string name, string abbreviation)
    {
        LeagueId = leagueId;
        Name = name.Trim();
        Abbreviation = abbreviation.Trim().ToUpperInvariant();
    }

    public void Update(string name, string abbreviation)
    {
        Name = name.Trim();
        Abbreviation = abbreviation.Trim().ToUpperInvariant();
    }
}