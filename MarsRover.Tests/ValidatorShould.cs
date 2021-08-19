using System;
using Xunit;

namespace MarsRover.Tests
{
    public class ValidatorShould
    {
        [Theory]
        [InlineData("ONNN\nNNNN\nNNNN")]
        [InlineData("NNNN\nNNNO\nNNNN")]
        [InlineData("ONN\nNNN\nNNN")]
        [InlineData("ONNNNON\nNNNNNNN\nNNNNNNN")]
        public void ReturnTrue_GivenValidMapString(string mapString)
        {
            var result = Validator.IsValidMap(mapString);

            Assert.True(result);
        }

        [Theory]
        [InlineData("ONNN")]
        [InlineData("ONNN\nNNN")]
        [InlineData("PNNN\nNNN")]
        public void ReturnFalse_GivenInvalidMapString(string mapString)
        {
            var result = Validator.IsValidMap(mapString);

            Assert.False(result);
        }

        [Theory]
        [InlineData("N")]
        [InlineData("n")]
        [InlineData("S")]
        [InlineData("s")]
        [InlineData("E")]
        [InlineData("e")]
        [InlineData("W")]
        [InlineData("w")]
        public void ReturnTrue_GivenValidDirectionString(string directionString)
        {
            var result = Validator.IsValidDirection(directionString);

            Assert.True(result);
        }

        [Theory]
        [InlineData("Enter")]
        [InlineData("1")]
        [InlineData("a")]
        [InlineData(".")]
        public void ReturnFalse_GivenInvalidDirectionString(string directionString)
        {
            var result = Validator.IsValidDirection(directionString);

            Assert.False(result);
        }
    }
}
