using FluentAssertions;

namespace Cleaner.Application.Tests;

public class PathRequestHandlerTests
{
    [Fact]
    public async Task NoCommandsShouldAtLeastGiveOneCleanedSpot()
    {
        // Arrange
        var sut = new PathRequestHandler();
        var request = new CleanRequestBuilder().Build();

        // Act
        var result = await sut.HandleRequest(request);

        // Assert
        result.commands.Should().Be(0);
        result.result.Should().Be(1);
    }

    [Fact]
    public async Task ShouldCountAllStepsWithOneCommand()
    {
        // Arrange
        var sut = new PathRequestHandler();
        var request = new CleanRequestBuilder().WithCommand("east", 4).Build();

        // Act
        var result = await sut.HandleRequest(request);

        // Assert
        result.commands.Should().Be(1);
        result.result.Should().Be(5);
    }

    [Fact]
    public async Task ShouldNotCountDoubleIfGoingBackAndForth()
    {
        // Arrange
        var sut = new PathRequestHandler();
        var request = new CleanRequestBuilder().WithCommand("east", 4).WithCommand("west", 4).Build();

        // Act
        var result = await sut.HandleRequest(request);

        // Assert
        result.commands.Should().Be(2);
        result.result.Should().Be(5);
    }

    [Fact]
    public async Task ShouldCountIfChangingDirection()
    {
        // Arrange
        var sut = new PathRequestHandler();
        var request = new CleanRequestBuilder().WithCommand("east", 4).WithCommand("north", 4).Build();

        // Act
        var result = await sut.HandleRequest(request);

        // Assert
        result.commands.Should().Be(2);
        result.result.Should().Be(9);
    }
}