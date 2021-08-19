using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public static class Validator
    {
        public static bool IsValidMap(string input) 
        {
            var lines = SplitInput(input, "\n");
            var numberOfLines = lines.Length;
            if (numberOfLines == 1) return false;
            var areAllLinesEqual = AreAllLinesEqual(lines);
            var areAllCharsValid = AreAllCharsValid(lines);
            if (!areAllLinesEqual || !areAllCharsValid) return false;
            return true;
        }

        private static bool AreAllLinesEqual(string[] lines)
        {
            foreach (var line in lines)
            {
                var linesAreEqualLength = lines.All(c => c.Length == line.Length);
                if (!linesAreEqualLength) return false;
            }
            return true;
        }

        private static bool AreAllCharsValid(string[] lines)
        {
            foreach (var line in lines)
            {
                var charsInLineAreValid = line.All(c => c == 'O' || c == 'N');
                if (!charsInLineAreValid) return false;
            }
            return true;
        }

        public static bool IsValidDirection(string input)
        {
            if (input.Equals("N", StringComparison.InvariantCultureIgnoreCase)) return true;
            if (input.Equals("S", StringComparison.InvariantCultureIgnoreCase)) return true;
            if (input.Equals("E", StringComparison.InvariantCultureIgnoreCase)) return true;
            if (input.Equals("W", StringComparison.InvariantCultureIgnoreCase)) return true;
            return false;
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
