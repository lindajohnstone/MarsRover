using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
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
            var expectedObstacleCount = 1;

            var result = MapParser.ParseMap("ONNN\nNNNN\nNNNN");
            var actualObstacleCount = result.Squares.FindAll(c => c.Content == SquareContent.Obstacle).Count;
            
            result.Squares.Should().HaveCount(12);
            result.Should().Equals(expected);
            Assert.Equal(expectedObstacleCount, actualObstacleCount);
            Assert.IsType<Map>(result);
        }
    }
}