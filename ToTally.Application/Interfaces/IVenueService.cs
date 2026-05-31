using ToTally.Application.DTOs.Venues;

namespace ToTally.Application.Interfaces;

public interface IVenueService
{
    // Create
    Task<Guid> CreateAsync(
        CreateVenueRequest createVenueDto,
        CancellationToken cancellationToken = default);
    // Read
    Task<IReadOnlyList<VenueDto>> GetAllAsync(
        CancellationToken cancellationToken = default);
    // Update

    // Delete
}