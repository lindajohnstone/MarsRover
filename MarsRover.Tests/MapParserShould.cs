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
            var expected = new Map(4, 3, squares);
            var expectedCount = 1;
            var actualCount = 0;

            var result = MapParser.ParseMap("ONNN\nNNNN\nNNNN");
            foreach(var square in result.Squares)
            {
                if (square.HasObstacle()) actualCount++;
            }

            Assert.Equal(12, result.Squares.Count());
            Assert.IsType<Map>(result);
            Assert.True(MarsRoverHelper.MapsAreEqual(expected, result));
            Assert.Equal(expectedCount, actualCount);
        }
    }
}