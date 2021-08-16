using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;

namespace MarsRover.Tests
{
    public class MapParserShould
    {
        [Fact]
        public void ReturnMap_GivenValidString()
        {
            var result = MapParser.ParseMap("ONNN\nNNNN\nNNNN");

            Assert.Equal(12, result.Squares.Count());
            Assert.IsType<Map>(result);
            Assert.Equal(1, result.Squares.Where(x => x.Content == SquareContent.Obstacle).Count());
        }
    }
}