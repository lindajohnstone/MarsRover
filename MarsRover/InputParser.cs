using System;
using System.Globalization;

namespace MarsRover
{
    public static class InputParser
    {
        public static Direction ParseDirection(string input) 
        // TODO: ignore case?? // does ReadLine(n) recognise a char or is it still a string?
        {
            if (input == "N" || input == "n") return Direction.North;
            if (input == "S" || input == "n") return Direction.South;
            if (input == "E") return Direction.East;
            if (input == "W") return Direction.West;
            return Direction.None;
        }
    }
}
