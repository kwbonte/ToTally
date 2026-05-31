using ToTally.Domain.Venues;

namespace ToTally.Application.Interfaces;

public interface IVenueRepository
{
    Task<IReadOnlyList<Venue>> GetAllAsync(
        CancellationToken cancellationToken = default);
}