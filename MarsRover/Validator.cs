using System;

namespace MarsRover
{
    public static class Validator
    {
        public static bool IsValidMap(string input)
        {
            var mapElements = input.Split(',');
            // loop through each element 
            // split into char array
            // if doesn't contain only 'N' or 'O' return false
            // return true
            foreach (var element in mapElements)
            {
                var mapChars = element.ToCharArray();
                foreach (var mapChar in mapChars)
                {
                    return (mapChar == 'O' || mapChar == 'N');
                }
            }
            return true;
        }
    }
}