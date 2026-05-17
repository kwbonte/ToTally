using Moq;
using ToTally.Application.Interfaces;
using ToTally.Domain.Leagues;
using ToTally.Infrastructure.Services;

namespace ToTally.Tests.Application.Services;

public sealed class LeagueServiceTests
{
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
}