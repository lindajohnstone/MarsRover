using System;
using System.Collections.Generic;

namespace MarsRover
{
    public static class MapParser
    {
        public static Map ParseMap(string input) 
        {
            var mapContents = SplitInput(input, "\n");
            var height = mapContents.Length;
            var width = mapContents[0].Length;
            var squares = new List<Square>();
            for (var y = 0; y < height; y++)
            {
                var chars = mapContents[y].ToCharArray();
                for (var x = 0; x < width; x++)
                {
                    AddContent(squares, chars, x, y);
                }
            }
            return new Map(width, height, squares);
        }

        private static void AddContent(List<Square> squares, char[] chars, int x, int y)
        {
            var squareContent = SquareContent.None;
            if (chars[x] == 'O') squareContent = SquareContent.Obstacle;
            squares.Add(new Square(squareContent, x, y));
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
