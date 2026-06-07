using ToTally.Application.DTOs.Teams;
using ToTally.Application.Interfaces;

namespace ToTally.Application.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;

    public TeamService(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public Task<List<TeamListItem>> GetAllTeamDumpAsync(CancellationToken cancellationToken = default)
    {
        return _teamRepository.GetAllTeamDumpAsync(cancellationToken);
    }
}