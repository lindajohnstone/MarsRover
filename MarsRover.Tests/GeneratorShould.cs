using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Xunit;

namespace MarsRover.Tests
{
    public class GeneratorShould
    {
        [Fact]
        public void GenerateRover_ReturnsRoverLocationAndDirection_GivenValidMapAndRoverData()
        {
            var x = 2;
            var y = 0;
            var direction = "N";
            var coordinates = new int[] { x, y };
            var mockInput = new Mock<IInput>();
            mockInput.SetupSequence(_ => _.Read())
                .Returns(direction)
                .Returns(string.Join(",", coordinates));
            var output = new StubOutput();
            var mockMapInput = new Mock<IMapInput>();
            var map = SetMap();
            var rover = new Rover(Direction.North, x, y); 
            var generator = new Generator(mockInput.Object, output, mockMapInput.Object, map, rover);
            var expectedDirection = Direction.North;

            generator.GenerateRover();

            rover.Direction.Should().Be(expectedDirection);
            rover.Location.X.Should().Be(x);
            rover.Location.Y.Should().Be(y);
        }

        public static Map SetMap()
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
            return map;
        }
    }
}