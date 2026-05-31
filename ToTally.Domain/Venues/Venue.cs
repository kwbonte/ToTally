using ToTally.Domain.Common;

namespace ToTally.Domain.Venues;

public sealed class Venue : EntityBase
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string City { get; private set; } = string.Empty;

    public string StateOrCountry { get; private set; } = string.Empty;

    public decimal? Latitude { get; private set; }

    public decimal? Longitude { get; private set; }

    public bool IsDome { get; private set; }

    public bool IsNeutralSiteCapable { get; private set; }

    private Venue()
    {
    }

    public Venue(
        string name,
        string city,
        string stateOrCountry,
        decimal? latitude = null,
        decimal? longitude = null,
        bool isDome = false,
        bool isNeutralSiteCapable = false)
    {
        Id = Guid.NewGuid();
        Name = name;
        City = city;
        StateOrCountry = stateOrCountry;
        Latitude = latitude;
        Longitude = longitude;
        IsDome = isDome;
        IsNeutralSiteCapable = isNeutralSiteCapable;
    }
}