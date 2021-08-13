using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public static class MapParser
    {
        public static Map ParseMap(string input)
        {
            // split string on \n
            // array index 0 = dimensions of map
            // split on','
            // index 0 = width
            // index 1 = height
            // array index 1 = map contents
            var lines = SplitInput(input, "\n"); 
            var dimensions = SplitInput(lines[0], ",");
            var width = Int32.Parse(dimensions[0]);
            var height = Int32.Parse(dimensions[1]);
            var squares = new List<Square>();
            var mapContents = lines.Skip(1).ToArray();
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; y++)
                {
                    var squareContent = SquareContent.None;
                    var chars = mapContents[x].ToCharArray();
                    foreach (var ch in chars)
                    {
                        if (ch == 'O') squareContent = SquareContent.Obstacle;
                    }
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