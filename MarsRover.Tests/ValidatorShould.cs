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
    }
}
