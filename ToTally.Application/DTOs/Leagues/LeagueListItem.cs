namespace ToTally.Application.DTOs.Leagues;

public sealed class LeagueListItem
{
    public int Id {get; init;}
    public string Name { get; init; } = string.Empty;
    public string Abbreviation { get; init; } = string.Empty;
    public string Sport { get; init; } = string.Empty;
}