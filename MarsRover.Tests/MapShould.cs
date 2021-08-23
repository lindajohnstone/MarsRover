using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Xunit;

namespace MarsRover.Tests
{
    public class MapShould
    {
        [Theory]
        [MemberData(nameof(MapShouldTestData.MapTestData), MemberType = typeof(MapShouldTestData))]
        public void GetSquareAtLocation_ReturnCorrectSquare_WhenGivenALocation(List<Square> squares, int width, int height, Location location, SquareContent contents)
        {
            var map = new Map(width, height, squares);
            var expected = new Square(contents, location.X, location.Y);

            var result = map.GetSquareAtLocation(location);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
