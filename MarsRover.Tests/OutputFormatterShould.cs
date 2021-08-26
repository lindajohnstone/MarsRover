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

            var result = OutputFormatter.DisplayMap(map);

            result.Should().BeEquivalentTo(expectedMap);
        }
        
        [Theory]
        [MemberData(nameof(OutputFormatterShouldTestData.FormatMapWithRoverTestData), MemberType = typeof(OutputFormatterShouldTestData))]
        public void FormatMap_ReturnsMapWithRover_GivenMapAndRover(List<Square> squares, int width, int height, params string[] inputs)
        {
            var map = new Map(width, height, squares);
            var rover = new Rover(Direction.North, 2, 1);
            var expectedMap = String.Join(Environment.NewLine, inputs);

            var result = OutputFormatter.DisplayMap(map, rover);

            result.Should().BeEquivalentTo(expectedMap);
        }
    }
}