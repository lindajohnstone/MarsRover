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

        public static Location ParseLocation(string input)
        {
            var coordinates = SplitInput(input, ",");
            var x = Int32.Parse(coordinates[0]);
            var y = Int32.Parse(coordinates[1]);
            return new Location(x, y);
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
