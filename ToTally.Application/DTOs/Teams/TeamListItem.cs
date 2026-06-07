namespace ToTally.Application.DTOs.Teams;

public class TeamListItem
{
    public int TeamId { get; set; }

    public string City { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Abbreviation { get; set; } = string.Empty;

    public string DisplayName => $"{City} {Name}";

    public int DivisionId { get; set; }

    public string DivisionName { get; set; } = string.Empty;

    public string DivisionAbbreviation { get; set; } = string.Empty;

    public int ConferenceId { get; set; }

    public string ConferenceName { get; set; } = string.Empty;

    public string ConferenceAbbreviation { get; set; } = string.Empty;

    public int LeagueId { get; set; }

    public string LeagueName { get; set; } = string.Empty;

    public string LeagueAbbreviation { get; set; } = string.Empty;

    public string Sport { get; set; } = string.Empty;

    public Guid VenueId { get; set; }

    public string VenueName { get; set; } = string.Empty;

    public string VenueCity { get; set; } = string.Empty;

    public string VenueStateOrCountry { get; set; } = string.Empty;
}