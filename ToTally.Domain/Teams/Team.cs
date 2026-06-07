using ToTally.Domain.Common;
using ToTally.Domain.Divisions;
using ToTally.Domain.Venues;

namespace ToTally.Domain.Teams;

public class Team : EntityBase
{
    public int Id { get; private set; }

    public int DivisionId { get; private set; }

    public Division Division { get; private set; } = null!;

    public Guid VenueId { get; private set; }

    public Venue Venue { get; private set; } = null!;

    public string Name { get; private set; } = string.Empty;

    public string Abbreviation { get; private set; } = string.Empty;

    public string City { get; private set; } = string.Empty;

    private Team()
    {
    }

    public Team(
        int divisionId,
        Guid venueId,
        string name,
        string abbreviation,
        string city)
    {
        DivisionId = divisionId;
        VenueId = venueId;
        Name = name.Trim();
        Abbreviation = abbreviation.Trim().ToUpperInvariant();
        City = city.Trim();
    }

    public void Update(
        int divisionId,
        Guid venueId,
        string name,
        string abbreviation,
        string city)
    {
        DivisionId = divisionId;
        VenueId = venueId;
        Name = name.Trim();
        Abbreviation = abbreviation.Trim().ToUpperInvariant();
        City = city.Trim();
    }
}