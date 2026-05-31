using ToTally.Application.DTOs.Venues;

namespace ToTally.Application.Interfaces;

public interface IVenueService
{
    Task<IReadOnlyList<VenueDto>> GetAllAsync(
        CancellationToken cancellationToken = default);
}