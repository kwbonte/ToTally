namespace ToTally.Application.DTOs.Sportsbook;

public sealed class AddTeamWinTotalRequest
{
    public int TeamId { get; init; }

    public Guid SportsbookId { get; init; }

    public int SeasonYear { get; init; }

    public decimal Total { get; init; }

    public int? OverOddsAmerican { get; init; }

    public int? UnderOddsAmerican { get; init; }

    public DateTimeOffset? ObservedOnUtc { get; init; }
}