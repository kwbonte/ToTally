using ToTally.Domain.SportsBook;

namespace ToTally.Application.Interfaces;

public interface ISportsbookInfoRepository
{
    Task<IReadOnlyList<TeamWinTotal>> GetCurrentTeamWinTotalsAsync(
        int seasonYear,
        CancellationToken cancellationToken = default);

    // Task AddTeamWinTotalAsync(
    //     AddTeamWinTotalRequest request,
    //     CancellationToken cancellationToken = default);
}