using System.Collections.Generic;

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
    }
}