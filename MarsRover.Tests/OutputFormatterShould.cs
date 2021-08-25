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
        public void FormatMap_ReturnsMapWithNoRover_GivenValidString(List<Square> squares, int width, int height, params string[] inputs)
        {
            var map = new Map(width, height, squares);
            var expectedMap = String.Join(Environment.NewLine, inputs);

            var result = OutputFormatter.FormatMap(map);

            result.Should().BeEquivalentTo(expectedMap);
        }
    }
}