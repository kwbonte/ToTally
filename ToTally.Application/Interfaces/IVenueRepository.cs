using ToTally.Domain.Venues;

namespace ToTally.Application.Interfaces;

public interface IVenueRepository
{
    // Create
    Task<Venue> CreateAsync(
        Venue venue,
        CancellationToken cancellationToken = default);
    // Read
    Task<IReadOnlyList<Venue>> GetAllAsync(
        CancellationToken cancellationToken = default);
}