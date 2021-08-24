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

        [Fact]
        public void HasObstacle_ReturnsTrue_GivenLocation()
        {
            var width = 5;
            var height = 4;
            var squares = new List<Square>
            {
                new Square(SquareContent.Obstacle, 0, 0),
                new Square(SquareContent.None, 1, 0),
                new Square(SquareContent.None, 2, 0),
                new Square(SquareContent.None, 3, 0),
                new Square(SquareContent.None, 4, 0),
                new Square(SquareContent.None, 0, 1),
                new Square(SquareContent.None, 1, 1),
                new Square(SquareContent.None, 2, 1),
                new Square(SquareContent.None, 3, 1),
                new Square(SquareContent.Obstacle, 4, 1),
                new Square(SquareContent.None, 0, 2),
                new Square(SquareContent.None, 1, 2),
                new Square(SquareContent.Obstacle, 2, 2),
                new Square(SquareContent.None, 3, 2),
                new Square(SquareContent.None, 4, 2),
                new Square(SquareContent.None, 0, 3),
                new Square(SquareContent.None, 1, 3),
                new Square(SquareContent.Obstacle, 2, 3),
                new Square(SquareContent.None, 3, 3),
                new Square(SquareContent.None, 4, 3)
            };
            var map = new Map(width, height, squares);

            var result = map.HasObstacle(new Location(0, 0));

            Assert.True(result);
        }
    }
}
