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
        public void ReturnMap_GivenValidString(List<Square> squares, int width, int height, int expectedObstacleCount, int expectedSquareCount, params string[] inputs)
        {
            var mapString = String.Join(Environment.NewLine, inputs);
            var expected = new Map(width, height, squares);

            var result = MapParser.ParseMap(mapString);
            var actualObstacleCount = result.Squares.FindAll(c => c.Content == SquareContent.Obstacle).Count;
            
            result.Squares.Should().HaveCount(expectedSquareCount);
            result.Should().Equals(expected);
            Assert.Equal(expectedObstacleCount, actualObstacleCount);
            Assert.IsType<Map>(result);
        }
    }
}
