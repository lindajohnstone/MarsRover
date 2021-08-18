using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace MarsRover.Tests
{
    public class MapParserShould
    {
        [Theory]
        [MemberData(nameof(MapParserShouldTestData.MapParserTestData), MemberType = typeof(MapParserShouldTestData))]
        public void ReturnMap_GivenValidString(List<Square> squares, int width, int height, int expectedObstacleCount)
        {
            var expected = new Map(width, height, squares);

            var result = MapParser.ParseMap("ONNN\nNNNN\nNNNN");
            var actualObstacleCount = result.Squares.FindAll(c => c.Content == SquareContent.Obstacle).Count;
            
            result.Squares.Should().HaveCount(12);
            result.Should().Equals(expected);
            Assert.Equal(expectedObstacleCount, actualObstacleCount);
            Assert.IsType<Map>(result);
        }
    }
}