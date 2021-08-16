using System;
using Xunit;

namespace MarsRover.Tests
{
    public class ValidatorShould
    {
        [Fact]
        public void ReturnTrue_GivenValidMapString()
        {
            var mapString = "ONNN\nNNNN\nNNNN";

            var result = Validator.IsValidMap(mapString);

            Assert.True(result);
        }
    }
}