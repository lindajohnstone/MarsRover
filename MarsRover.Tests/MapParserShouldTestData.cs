using System;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.Tests
{
    public class MapParserShouldTestData
    {
        public static TheoryData<List<Square>, int, int, int> MapParserTestData =
            new TheoryData<List<Square>, int, int, int>
            {
                {
                    new List<Square>
                    {
                        new Square(SquareContent.Obstacle, 0, 0),
                        new Square(SquareContent.None, 1, 0),
                        new Square(SquareContent.None, 2, 0),
                        new Square(SquareContent.None, 3, 0),
                        new Square(SquareContent.None, 0, 1),
                        new Square(SquareContent.None, 1, 1),
                        new Square(SquareContent.None, 2, 1),
                        new Square(SquareContent.None, 3, 1),
                        new Square(SquareContent.None, 0, 2),
                        new Square(SquareContent.None, 1, 2),
                        new Square(SquareContent.None, 2, 2),
                        new Square(SquareContent.None, 3, 2)
                    },
                    4,
                    3,
                    1
                }
            };
    }
}