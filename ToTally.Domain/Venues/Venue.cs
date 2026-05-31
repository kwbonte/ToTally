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
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Venue name is required.", nameof(name));
        }

        if (string.IsNullOrWhiteSpace(city))
        {
            throw new ArgumentException("City is required.", nameof(city));
        }

        if (string.IsNullOrWhiteSpace(stateOrCountry))
        {
            throw new ArgumentException("State or country is required.", nameof(stateOrCountry));
        }

        if (latitude is < -90 or > 90)
        {
            throw new ArgumentOutOfRangeException(
                nameof(latitude),
                "Latitude must be between -90 and 90.");
        }

        if (longitude is < -180 or > 180)
        {
            throw new ArgumentOutOfRangeException(
                nameof(longitude),
                "Longitude must be between -180 and 180.");
        }

        Id = Guid.NewGuid();
        Name = name.Trim();
        City = city.Trim();
        StateOrCountry = stateOrCountry.Trim();
        Latitude = latitude;
        Longitude = longitude;
        IsDome = isDome;
        IsNeutralSiteCapable = isNeutralSiteCapable;
    }
}