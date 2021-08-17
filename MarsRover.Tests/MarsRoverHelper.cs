using System;

namespace MarsRover.Tests
{
    public static class MarsRoverHelper
    {
        public static bool MapsAreEqual(Map map1, Map map2)
        {
            if (map1 == null || map2 == null ) return false;
            if (map1.Squares != map2.Squares) return false;
            return true;
        }
        private static bool LocationsAreEqual(Location location1, Location location2)
        {
            throw new NotImplementedException();
        }
    }
}