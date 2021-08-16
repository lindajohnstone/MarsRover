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
            // if has less than 2 elements, return false
            // count the length of each line, if all !=, return false
            // loop through each element 
            // split into char array
            // if doesn't contain only 'N' or 'O' return false
            // return true
            var numberOfElements = mapElements.Length;
            if (numberOfElements == 1) return false;
            var elementList = new List<int>();
            var mapCharsCount = 0;
            var count = 0;
            foreach (var element in mapElements)
            {
                var mapChars = element.ToCharArray();
                mapCharsCount = mapChars.Length;
                elementList.Add(mapCharsCount);
                foreach (var mapChar in mapChars)
                {
                    if (mapChar == 'O' || mapChar == 'N') count++;
                }
            }
            if (count == mapCharsCount) return true;
            if (elementList.Distinct().Count() != 1) return false;
            return true;
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}