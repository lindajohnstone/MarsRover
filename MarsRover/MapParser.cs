using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public static class MapParser
    {
        public static Map ParseMap(string input) 
        {
            var mapContents = SplitInput(input, "\n");
            var height = mapContents.Length;
            var width = 0;
            var squares = new List<Square>();
            for (var y = 0; y < height; y++)
            {
                var chars = mapContents[y].ToCharArray();
                width = chars.Length;
                for (var x = 0; x < chars.Length; x++)
                {
                    var squareContent = SquareContent.None;
                    if (chars[x] == 'O') squareContent = SquareContent.Obstacle;
                    squares.Add(new Square(squareContent, x, y));
                }
            }
            return new Map(width, height, squares);
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}