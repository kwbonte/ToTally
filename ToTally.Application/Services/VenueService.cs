using ToTally.Application.DTOs.Venues;
using ToTally.Application.Interfaces;
using ToTally.Domain.Venues;

namespace ToTally.Application.Services;

public sealed class VenueService : IVenueService
{
    private readonly IVenueRepository _venueRepository;

    public VenueService(IVenueRepository venueRepository)
    {
        _venueRepository = venueRepository ?? throw new ArgumentNullException(nameof(venueRepository));
    }

    #region Create
    public async Task<Guid> CreateAsync(
        CreateVenueRequest createVenueDto,
        CancellationToken cancellationToken = default)
    {
         var venue = new Venue(
        createVenueDto.Name,
        createVenueDto.City,
        createVenueDto.StateOrCountry,
        createVenueDto.Latitude,
        createVenueDto.Longitude,
        createVenueDto.IsDome,
        createVenueDto.IsNeutralSiteCapable);

        venue.MarkCreated(
            userId: "kwbonte", // Change if other people work on this project
            nowUtc: DateTimeOffset.UtcNow);

        var createdVenue = await _venueRepository.CreateAsync(
            venue,
            cancellationToken);
        return createdVenue.Id;
        // return MapToDto(createdVenue);
    }
    #endregion

    #region Read
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
    #endregion
}