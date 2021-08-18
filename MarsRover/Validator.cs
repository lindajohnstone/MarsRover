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
                var linesAreEqual = lines.All(c => c.Length == line.Length);
                if (!linesAreEqual) return false;
            }
            return true;
        }

        private static bool AreAllCharsValid(string[] lines)
        {
            foreach (var line in lines)
            {
                var charsInElementAreValid = line.All(c => c == 'O' || c == 'N');
                if (!charsInElementAreValid) return false;
            }
            return true;
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}