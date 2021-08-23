using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace MarsRover.Tests
{
    public class MapParserShould
    {
        [Theory]
        [MemberData(nameof(MapParserShouldTestData.MapParserTestData), MemberType = typeof(MapParserShouldTestData))]
        public void ParseMap_ReturnsMap_GivenValidString(List<Square> squares, int width, int height, params string[] inputs)
        {
            var mapString = String.Join(Environment.NewLine, inputs);
            var expected = new Map(width, height, squares);

            var result = MapParser.ParseMap(mapString);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
