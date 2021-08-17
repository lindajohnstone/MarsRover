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
            var width = mapContents[0].Length;
            var squares = new List<Square>();
            ParseMap(mapContents, height, width, squares);
            return new Map(width, height, squares);
        }

        private static void ParseMap(string[] mapContents, int height, int width, List<Square> squares)
        {
            for (var y = 0; y < height; y++)
            {
                var chars = mapContents[y].ToCharArray();
                for (var x = 0; x < width; x++)
                {
                    AddContent(squares, chars, x, y);
                }
            }
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