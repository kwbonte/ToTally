using ToTally.Domain.Leagues;

namespace ToTally.Application.Interfaces;

public interface ILeagueRepository
{
    Task<IReadOnlyList<League>> GetAllAsync(
        CancellationToken cancellationToken = default);
}