using System;
using System.Globalization;

namespace MarsRover
{
    public static class InputParser
    {
        public static Direction ParseDirection(string input)
        {
            var upperInput = input.ToUpper();
            return upperInput switch {
                "N" => Direction.North,
                "S" => Direction.South,
                "E" => Direction.East,
                "W" => Direction.West,
                _ => Direction.None
            };

            // if (input.Equals("N", StringComparison.InvariantCultureIgnoreCase)) return Direction.North;
            // if (input == "S" || input == "s") return Direction.South;
            // if (input == "E") return Direction.East;
            // if (input == "W") return Direction.West;
            // return Direction.None;
        }
    }
}
