using System;
using System.Globalization;

namespace MarsRover
{
    public static class InputParser
    {
        public static Direction ParseDirection(string input)
        {
            if (input.Equals("N", StringComparison.InvariantCultureIgnoreCase)) return Direction.North;
            if (input.Equals("S", StringComparison.InvariantCultureIgnoreCase)) return Direction.South;
            if (input.Equals("E", StringComparison.InvariantCultureIgnoreCase)) return Direction.East;
            if (input.Equals("W", StringComparison.InvariantCultureIgnoreCase)) return Direction.West;
            return Direction.None;
        }
    }
}
