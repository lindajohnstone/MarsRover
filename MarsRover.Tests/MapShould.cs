using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Xunit;

namespace MarsRover.Tests
{
    public class MapShould
    {
        [Theory]
        [MemberData(nameof(MapShouldTestData.GetSquareAtLocationTestData), MemberType = typeof(MapShouldTestData))]
        public void GetSquareAtLocation_ReturnCorrectSquare_GivenLocation(List<Square> squares, int width, int height, Location location, SquareContent contents)
        {
            var map = new Map(width, height, squares);
            var expected = new Square(contents, location.X, location.Y);

            var result = map.GetSquareAtLocation(location);

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(MapShouldTestData.HasObstacleTestData), MemberType = typeof(MapShouldTestData))]
        public void HasObstacle_ReturnsTrue_GivenLocation(int x, int y)
        {
            Map map = MapShouldTestData.SetMap();

            var result = map.HasObstacle(new Location(x, y));

            Assert.True(result);
        }
    }
}
