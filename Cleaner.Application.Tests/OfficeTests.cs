using FluentAssertions;

namespace Cleaner.Application.Tests;

public class OfficeTests
{
    private const int minimumX = -100000;
    private const int minimumY = -100000;
    private const int maxX = 100000;
    private const int maxY = 100000;

    [Fact]
    public void ShouldBeAbleToSetMinimumXandY()
    {
        // Arrange
        var sut = new Office();
        var coordinate = new Coordinate() { x = minimumX, y = minimumY };

        // Act
        sut.Set(coordinate);

        // Assert
        sut.Get(coordinate).Should().BeTrue();
        sut.GetCount().Should().Be(1);
    }

    [Fact]
    public void ShouldBeAbleToSetMaximumXandY()
    {
        // Arrange
        var sut = new Office();
        var coordinate = new Coordinate() { x = maxX, y = maxY };

        // Act
        sut.Set(coordinate);

        // Assert
        sut.Get(coordinate).Should().BeTrue();
        sut.GetCount().Should().Be(1);
    }

    [Fact]
    public void ShouldBeAbleToSetOrigo()
    {
        // Arrange
        var sut = new Office();
        var coordinate = new Coordinate() { x = 0, y = 0 };

        // Act
        sut.Set(coordinate);

        // Assert
        sut.Get(coordinate).Should().BeTrue();
        sut.GetCount().Should().Be(1);
    }

    [Fact]
    public void CanSetManyCoordinates()
    {
        // Arrange
        var sut = new Office();
        var coordinates = new List<Coordinate>()
        {
            new Coordinate() { x = 0, y = 0},
            new Coordinate() { x = 1, y = 0},
            new Coordinate() { x = 1, y = 1},
            new Coordinate() { x = 2, y = 1},
            new Coordinate() { x = 2, y = 2},
        };

        // Act
        sut.Set(coordinates);

        // Assert
        foreach (var coord in coordinates)
        {
            sut.Get(coord).Should().BeTrue();
        }
        sut.GetCount().Should().Be(coordinates.Count);
    }
}