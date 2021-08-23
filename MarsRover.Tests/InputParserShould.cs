using System;
using FluentAssertions;
using Xunit;

namespace MarsRover.Tests
{
    public class InputParserShould
    {
        [Theory]
        [InlineData("N", Direction.North)]
        [InlineData("n", Direction.North)]
        [InlineData("S", Direction.South)]
        [InlineData("s", Direction.South)]
        [InlineData("E", Direction.East)]
        [InlineData("e", Direction.East)]
        [InlineData("W", Direction.West)]
        [InlineData("w", Direction.West)]
        public void ParseDirection_ReturnDirection_GivenValidString(string input, Direction expected)
        {
            var result = InputParser.ParseDirection(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("0,0", 0, 0)]
        [InlineData("100,8", 100, 8)]
        [InlineData("1,80", 1, 80)]
        public void ParseLocation_ReturnLocation_GivenValidString(string input, int x, int y)
        {
            var expected = new Location(x, y);

            var result = InputParser.ParseLocation(input);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
