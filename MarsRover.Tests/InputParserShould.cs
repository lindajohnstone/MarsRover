using System;
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
        public void ReturnRoverStartDirection_GivenValidString(string input, Direction expected)
        {
            var result = InputParser.ParseDirection(input);

            Assert.Equal(expected, result);
        }
    }
}
