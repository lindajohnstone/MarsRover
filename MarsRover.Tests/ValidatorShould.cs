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
        public void IsValidMap_ReturnTrue_GivenValidMapString(string mapString)
        {
            var result = Validator.IsValidMap(mapString);

            Assert.True(result);
        }

        [Theory]
        [InlineData("ONNN")]
        [InlineData("ONNN\nNNN")]
        [InlineData("PNNN\nNNN")]
        public void IsValidMap_ReturnFalse_GivenInvalidMapString(string mapString)
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
        public void IsValidDirection_ReturnTrue_GivenValidDirectionString(string directionString)
        {
            var result = Validator.IsValidDirection(directionString);

            Assert.True(result);
        }

        [Theory]
        [InlineData("Enter")]
        [InlineData("1")]
        [InlineData("a")]
        [InlineData(".")]
        public void IsValidDirection_ReturnFalse_GivenInvalidDirectionString(string directionString)
        {
            var result = Validator.IsValidDirection(directionString);

            Assert.False(result);
        }

        [Theory]
        [InlineData("0,0", 4, 3)]
        [InlineData("24,5", 25, 10)]
        [InlineData("99,0", 100, 3)]
        [InlineData("0,10", 20, 20)]
        public void IsValidLocation_ReturnTrue_GivenValidLocationString(string input, int width, int height)
        {
            var result = Validator.IsValidLocation(input, width, height);

            Assert.True(result);
        }

        [Theory]
        [InlineData("10", 15, 10)]
        [InlineData("15,8", 15, 10)]
        [InlineData("4 4", 4, 3)]
        [InlineData(",,", 3, 3)]
        [InlineData("3,3,", 4, 3)]
        [InlineData("3,3,3", 4, 3)]
        [InlineData("a,b", 3, 3)]
        [InlineData("-1,4", 3, 3)]
        [InlineData("4,-1", 3, 3)]
        [InlineData("0,0", -10, 3)]
        [InlineData("0,0", 3, -10)]
        public void IsValidLocation_ReturnFalse_GivenInvalidLocationString(string input, int width, int height)
        {
            var result = Validator.IsValidLocation(input, width, height);

            Assert.False(result);
        }

        [Theory]
        [InlineData("flfr")]
        [InlineData("blbr")]
        public void AreCommandsValid_ReturnsTrue_GivenValidCommandString(string input) 
        {
            var result = Validator.AreCommandsValid(input);

            Assert.True(result);
        }

        [Theory]
        [InlineData("flkr")]
        [InlineData("1234")]
        [InlineData("_flkr")]
        public void AreCommandsValid_ReturnFalse_GivenInvalidCommandString(string input)
        {
            var result = Validator.AreCommandsValid(input);

            Assert.False(result);
        }
    }
}
