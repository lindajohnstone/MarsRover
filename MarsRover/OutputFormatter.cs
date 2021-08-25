using System;
using System.Text;

namespace MarsRover
{
    public static class OutputFormatter
    {
        public static string FormatMap(Map map)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (var y = 0; y < map.Height; y++)
            {
                for (var x = 0; x < map.Width; x++)
                {
                    var location = new Location(x, y);
                    var square = map.GetSquareAtLocation(location);
                    if (square.HasObstacle())
                    {
                        stringBuilder.Append("O");
                    }
                    else stringBuilder.Append("N");
                }
                stringBuilder.Append(Environment.NewLine);
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}