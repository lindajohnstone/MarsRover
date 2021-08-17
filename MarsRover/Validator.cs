using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public static class Validator
    {
        public static bool IsValidMap(string input) // TODO: refactor
        {
            var mapElements = SplitInput(input, "\n");
            var numberOfElements = mapElements.Length;
            if (numberOfElements == 1) return false;
            for (var i = 0; i < numberOfElements - 1; i++)
            {
                if (mapElements[i].Length != mapElements[i + 1].Length) return false;
            }
            var mapCharsCount = 0;
            var count = 0;
            foreach (var element in mapElements)
            {
                var mapChars = element.ToCharArray();
                mapCharsCount = mapChars.Length;
                foreach (var mapChar in mapChars)
                {
                    if (mapChar == 'O' || mapChar == 'N') count++;
                }
            }
            if (count == mapCharsCount) return true;
            return true;
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}