namespace ToTally.Application.DTOs.Sportsbook;

public sealed class SportsbookTeamWinTotalInfo
{
    public int TeamId { get; init; }

    public string TeamCity { get; init; } = string.Empty;

    public string TeamName { get; init; } = string.Empty;

    public string TeamAbbreviation { get; init; } = string.Empty;

    public Guid SportsbookId { get; init; }

    public string SportsbookName { get; init; } = string.Empty;

    public string SportsbookCode { get; init; } = string.Empty;

    public int SeasonYear { get; init; }

    public decimal Total { get; init; }

    public int? OverAmericanOdds { get; init; }

    public int? UnderAmericanOdds { get; init; }

    public DateTimeOffset ObservedOnUtc { get; init; }
}