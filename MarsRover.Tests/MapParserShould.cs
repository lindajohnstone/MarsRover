using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;

namespace MarsRover.Tests
{
    public class MapParserShould
    {
        [Fact]
        public void ReturnMap_GivenValidString()
        {
            var squares = new List<Square>
            {
                new Square(SquareContent.Obstacle, 0, 0),
                new Square(SquareContent.None, 1, 0),
                new Square(SquareContent.None, 2, 0),
                new Square(SquareContent.None, 0, 1),
                new Square(SquareContent.None, 1, 1),
                new Square(SquareContent.None, 2, 1),
                new Square(SquareContent.None, 0, 2),
                new Square(SquareContent.None, 1, 2),
                new Square(SquareContent.None, 2, 2),
                new Square(SquareContent.None, 0, 3),
                new Square(SquareContent.None, 1, 3),
                new Square(SquareContent.None, 2, 3)
            };
            var expected = new Map(squares);

            var result = MapParser.ParseMap("ONNN\nNNNN\nNNNN");

            Assert.Equal(12, result.Squares.Count());
            Assert.IsType<Map>(result);
            Assert.True(MarsRoverHelper.MapsAreEqual(expected, result));
            // TODO: how to count squares with Obstacles without violating the Law of Demeter??
        }
    }
}