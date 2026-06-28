using ToTally.Application.DTOs.Sportsbook;

namespace ToTally.Application.Interfaces;
public interface ISportsbookInfoService
{
    Task<IReadOnlyList<SportsbookTeamWinTotalInfo>> GetCurrentTeamWinTotalsAsync(
        int seasonYear,
        CancellationToken cancellationToken = default);

    // Task AddTeamWinTotalAsync(
    //     AddTeamWinTotalRequest request,
    //     CancellationToken cancellationToken = default);
}