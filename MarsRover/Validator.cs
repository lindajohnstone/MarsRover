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
            var elementList = new List<int>();
            var mapCharsCount = 0;
            var count = 0;
            CountValidChars(mapElements, elementList, ref mapCharsCount, ref count);
            if (count == mapCharsCount) return true;
            if (elementList.Distinct().Count() != 1) return false;
            return true;
        }

        private static void CountValidChars(string[] mapElements, List<int> elementList, ref int mapCharsCount, ref int count)
        {
            foreach (var element in mapElements)
            {
                var mapChars = element.ToCharArray();
                mapCharsCount = mapChars.Length;
                elementList.Add(mapCharsCount);
                CountValidChars(count, mapChars);
            }
        }

        private static void CountValidChars(int count, char[] mapChars)
        {
            foreach (var mapChar in mapChars)
            {
                if (mapChar == 'O' || mapChar == 'N') count++;
            }
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}