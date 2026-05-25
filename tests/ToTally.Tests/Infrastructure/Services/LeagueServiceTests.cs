using Moq;
using ToTally.Application.Interfaces;
using ToTally.Domain.Leagues;
using ToTally.Infrastructure.Services;

namespace ToTally.Tests.Application.Services;

public sealed class LeagueServiceTests
{
   [Fact]
    public void Constructor_WhenRepositoryIsNull_ThrowsArgumentNullException()
    {
        // Act
        var exception = Assert.Throws<ArgumentNullException>(() =>
            new LeagueService(null!));

        // Assert
        Assert.Equal("leagueRepository", exception.ParamName);
    }

    [Fact]
    public async Task GetAllAsync_WhenLeaguesExist_ReturnsAllLeaguesOrderedByName()
    {
        // Arrange
        var repositoryMock = new Mock<ILeagueRepository>();

        repositoryMock
            .Setup(repository => repository.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<League>
            {
                new("National Football League", "NFL", "Football"),
                new("Major League Baseball", "MLB", "Baseball"),
                new("National Basketball Association", "NBA", "Basketball")
            });

        var service = new LeagueService(repositoryMock.Object);

        // Act
        var result = await service.GetAllAsync();

        // Assert
        Assert.Equal(3, result.Count);

        Assert.Equal("Major League Baseball", result[0].Name);
        Assert.Equal("National Basketball Association", result[1].Name);
        Assert.Equal("National Football League", result[2].Name);

        repositoryMock.Verify(
            repository => repository.GetAllAsync(It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_WhenLeaguesExist_MapsLeaguePropertiesToListItems()
    {
        // Arrange
        var repositoryMock = new Mock<ILeagueRepository>();

        repositoryMock
            .Setup(repository => repository.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<League>
            {
                new("National Football League", "nfl", "Football")
            });

        var service = new LeagueService(repositoryMock.Object);

        // Act
        var result = await service.GetAllAsync();

        // Assert
        var league = Assert.Single(result);

        Assert.Equal("National Football League", league.Name);
        Assert.Equal("NFL", league.Abbreviation);
        Assert.Equal("Football", league.Sport);
    }

    [Fact]
    public async Task GetAllAsync_WhenNoLeaguesExist_ReturnsEmptyList()
    {
        // Arrange
        var repositoryMock = new Mock<ILeagueRepository>();

        repositoryMock
            .Setup(repository => repository.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync([]);

        var service = new LeagueService(repositoryMock.Object);

        // Act
        var result = await service.GetAllAsync();

        // Assert
        Assert.Empty(result);

        repositoryMock.Verify(
            repository => repository.GetAllAsync(It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_PassesCancellationTokenToRepository()
    {
        // Arrange
        var repositoryMock = new Mock<ILeagueRepository>();
        using var cancellationTokenSource = new CancellationTokenSource();

        repositoryMock
            .Setup(repository => repository.GetAllAsync(cancellationTokenSource.Token))
            .ReturnsAsync([]);

        var service = new LeagueService(repositoryMock.Object);

        // Act
        await service.GetAllAsync(cancellationTokenSource.Token);

        // Assert
        repositoryMock.Verify(
            repository => repository.GetAllAsync(cancellationTokenSource.Token),
            Times.Once);
    }
}