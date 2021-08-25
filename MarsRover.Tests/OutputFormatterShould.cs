using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace MarsRover.Tests
{
    public class OutputFormatterShould
    {
        [Theory]
        [MemberData(nameof(OutputFormatterShouldTestData.FormatMapNoRoverTestData), MemberType = typeof(OutputFormatterShouldTestData))]
        public void FormatMap_ReturnsMapWithNoRover_GivenMap(List<Square> squares, int width, int height, params string[] inputs)
        {
            var map = new Map(width, height, squares);
            var expectedMap = String.Join(Environment.NewLine, inputs);

            var result = OutputFormatter.FormatMap(map);

            result.Should().BeEquivalentTo(expectedMap);
        }

        [Fact]
        public void FormatMap_ReturnsMapWithRover_GivenMapAndRover()
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
            var map = new Map(4, 3, squares);
            var inputs = new string[]
            {
                "ONNN",
                "NNNN",
                "NNRN"
            };
            var rover = new Rover(Direction.North, 2, 2);
            var expectedMap = String.Join(Environment.NewLine, inputs);

            var result = OutputFormatter.FormatMap(map, rover);

            result.Should().BeEquivalentTo(expectedMap);
        }
    }
}