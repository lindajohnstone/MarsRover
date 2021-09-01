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
        public void FormatMap_ReturnsMapWithNoRover_GivenMap(List<Square> squares, int width, int height, params string[] lines)
        {
            var map = new Map(width, height, squares);
            var expectedMap = String.Join(Environment.NewLine, lines);

            var result = OutputFormatter.DisplayMap(map);

            result.Should().BeEquivalentTo(expectedMap);
        }
        
        [Theory]
        [MemberData(nameof(OutputFormatterShouldTestData.FormatMapWithRoverTestData), MemberType = typeof(OutputFormatterShouldTestData))]
        public void FormatMap_ReturnsMapWithRover_GivenMapAndRover(List<Square> squares, int width, int height, int x, int y, Direction direction, params string[] lines)
        {
            var map = new Map(width, height, squares);
            var rover = new Rover(direction, x, y);
            var expectedMap = String.Join(Environment.NewLine, lines);

            var result = OutputFormatter.DisplayMap(map, rover);

            result.Should().BeEquivalentTo(expectedMap);
        }
    }
}
