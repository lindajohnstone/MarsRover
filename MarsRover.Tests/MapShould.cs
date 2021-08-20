using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Xunit;

namespace MarsRover.Tests
{
    public class MapShould
    {
        [Fact]
        public void WhenGivenALocation_ReturnCorrectSquare()
        {
            var width = 4;
            var height = 3;
            var squares = new List<Square>
            {
                new Square(SquareContent.Obstacle, 0, 0),
                new Square(SquareContent.None, 1, 0),
                new Square(SquareContent.None, 2, 0),
                new Square(SquareContent.None, 3, 0),
                new Square(SquareContent.None, 0, 1),
                new Square(SquareContent.None, 1, 1),
                new Square(SquareContent.None, 2, 1),
                new Square(SquareContent.None, 3, 1),
                new Square(SquareContent.None, 0, 2),
                new Square(SquareContent.None, 1, 2),
                new Square(SquareContent.None, 2, 2),
                new Square(SquareContent.None, 3, 2)
            };
            var x = 0;
            var y = 0;
            var map = new Map(width, height, squares);
            var location = new Location(x, y);
            var expected = new Square(SquareContent.Obstacle, x, y);

            var result = map.GetSquareAtLocation(location);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
