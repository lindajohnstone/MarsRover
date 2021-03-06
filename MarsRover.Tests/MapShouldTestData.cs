using System.Collections.Generic;
using Xunit;

namespace MarsRover.Tests
{
    public class MapShouldTestData
    {
        public static TheoryData<List<Square>, int, int, Location, SquareContent> GetSquareAtLocationTestData =
            new TheoryData<List<Square>, int, int, Location, SquareContent>
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
                    new Location(0, 0),
                    SquareContent.Obstacle
                },
                {
                    new List<Square>
                    {
                        new Square(SquareContent.Obstacle, 0, 0),
                        new Square(SquareContent.None, 1, 0),
                        new Square(SquareContent.None, 2, 0),
                        new Square(SquareContent.None, 3, 0),
                        new Square(SquareContent.None, 4, 0),
                        new Square(SquareContent.None, 0, 1),
                        new Square(SquareContent.None, 1, 1),
                        new Square(SquareContent.None, 2, 1),
                        new Square(SquareContent.None, 3, 1),
                        new Square(SquareContent.Obstacle, 4, 1),
                        new Square(SquareContent.None, 0, 2),
                        new Square(SquareContent.None, 1, 2),
                        new Square(SquareContent.Obstacle, 2, 2),
                        new Square(SquareContent.None, 3, 2),
                        new Square(SquareContent.None, 4, 2),
                        new Square(SquareContent.None, 0, 3),
                        new Square(SquareContent.None, 1, 3),
                        new Square(SquareContent.Obstacle, 2, 3),
                        new Square(SquareContent.None, 3, 3),
                        new Square(SquareContent.None, 4, 3)
                    },
                    5,
                    4,
                    new Location(3, 3),
                    SquareContent.None
                }
            };
    }
}
