using ToTally.Application.DTOs.Venues;
using ToTally.Application.Interfaces;

namespace ToTally.Application.Services;

public sealed class VenueService : IVenueService
{
    private readonly IVenueRepository _venueRepository;

    public VenueService(IVenueRepository venueRepository)
    {
        _venueRepository = venueRepository ?? throw new ArgumentNullException(nameof(venueRepository));
    }

    public async Task<IReadOnlyList<VenueDto>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var venues = await _venueRepository.GetAllAsync(cancellationToken);

        return venues
            .OrderBy(venue => venue.Name)
            .Select(venue => new VenueDto
            {
                Id = venue.Id,
                Name = venue.Name,
                City = venue.City,
                StateOrCountry = venue.StateOrCountry,
                Latitude = venue.Latitude,
                Longitude = venue.Longitude,
                IsDome = venue.IsDome,
                IsNeutralSiteCapable = venue.IsNeutralSiteCapable
            })
            .ToList();
    }
}