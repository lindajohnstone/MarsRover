using System.Collections.Generic;

namespace MarsRover
{
    public class Map
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Map(List<Square> squares)
        {
            Squares = squares;
        }
        public List<Square> Squares { get; private set; }
    }
}