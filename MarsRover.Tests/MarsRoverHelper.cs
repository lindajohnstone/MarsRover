using System;
using System.Collections.Generic;

namespace MarsRover.Tests
{
    public static class MarsRoverHelper
    {
        public static bool MapsAreEqual(Map map1, Map map2)
        {
            if (map1 == null || map2 == null ) return false;
            var isSizeSame = (map1.Width == map2.Width) && (map1.Height == map2.Height);
            if (!isSizeSame)
            {
                return false;
            }
            if (!ListsOfSquaresAreEqual(map1.Squares, map2.Squares)) return false;
            return true;
        }

        public static bool ListsOfSquaresAreEqual(List<Square> squares1, List<Square> squares2)
        {
            if (squares1.Count != squares2.Count)
            {
                return false;
            }

            for (var i = 0; i < squares1.Count; i++)
            {
                if (!SquaresAreEqual(squares1[i], squares2[i])) return false;
            }
            return true;
        }

        private static bool SquaresAreEqual(Square square1, Square square2)
        {
            if (square1.Content != square2.Content) return false;
            if (!LocationsAreEqual(square1.Location, square2.Location)) return false;
            return true;
        }

        private static bool LocationsAreEqual(Location location1, Location location2)
        {
            if (location1.X == location2.X && location1.Y == location2.Y) return true;
            return false;
        }
    }
}