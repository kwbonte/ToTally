namespace ToTally.Application.DTOs.Venues;
public sealed class VenueDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string StateOrCountry { get; set; } = string.Empty;

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public bool IsDome { get; set; }

    public bool IsNeutralSiteCapable { get; set; }
}