using System;
using Xunit;

namespace MarsRover.Tests
{
    public class ValidatorShould
    {
        [Fact]
        public void ReturnTrue_GivenValidMapInput()
        {
            var mapString = "ONNN\nNNNN\nNNNN";

            var result = Validator.IsValidMap(mapString);

            Assert.True(result);
        }
    }
}