namespace ToTally.Tests;

public class UnitTest1
{
    [Fact]
    public void Test_ProjectCanRunBasicAssertion()
    {
        // Arrange
        var expected = 4;

        // Act
        var actual = 2 + 2;

        // Assert
        Assert.Equal(expected, actual);
    }
}