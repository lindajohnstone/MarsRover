using System.Collections.Generic;

namespace MarsRover
{
    public class Map
    {
        public Map(List<Square> squares)
        {
            Squares = squares;
        }
        public List<Square> Squares { get; private set; }
    }
}