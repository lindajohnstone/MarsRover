using System;
using System.Collections.Generic;
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

        public static List<Commands> ParseCommands(string commands)
        {
            var upperCommands = commands.ToUpper();
            var commandsList = new List<Commands>();
            foreach (var command in upperCommands)
            {
                AddCommand(commandsList, command);
            }
            return commandsList;
        }

        private static void AddCommand(List<Commands> commandsList, char command)
        {
            switch (command)
            {
                case 'F':
                    commandsList.Add(Commands.Forward);
                    break;
                case 'B':
                    commandsList.Add(Commands.Backward);
                    break;
                case 'L':
                    commandsList.Add(Commands.TurnLeft);
                    break;
                case 'R':
                    commandsList.Add(Commands.TurnRight);
                    break;

            }
        }
    }
}
