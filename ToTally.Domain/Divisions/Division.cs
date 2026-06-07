using ToTally.Domain.Common;
using ToTally.Domain.Conferences;

namespace ToTally.Domain.Divisions;

public class Division : EntityBase
{
    public int Id { get; private set; }

    public int ConferenceId { get; private set; }
    public Conference Conference { get; private set; } = null!;

    public string Name { get; private set; } = string.Empty;
    public string Abbreviation { get; private set; } = string.Empty;

    private Division()
    {
    }

    public Division(int conferenceId, string name, string abbreviation)
    {
        ConferenceId = conferenceId;
        Name = name.Trim();
        Abbreviation = abbreviation.Trim().ToUpperInvariant();
    }

    public void Update(string name, string abbreviation)
    {
        Name = name.Trim();
        Abbreviation = abbreviation.Trim().ToUpperInvariant();
    }
}