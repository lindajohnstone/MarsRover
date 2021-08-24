using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Map
    {
        public Map(int width, int height, List<Square> squares)
        {
            Width = width;
            Height = height;
            Squares = squares;
        }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public List<Square> Squares { get; private set; }

        public Square GetSquareAtLocation(Location location)
        {
            return Squares.FirstOrDefault(square => square.Location.X == location.X && square.Location.Y == location.Y);
        }

        public bool HasObstacle(Location location)
        {
            var square = GetSquareAtLocation(location);
            return square.HasObstacle();
        }
    }
}
