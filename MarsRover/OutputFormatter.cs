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
                        stringBuilder.Append("O");
                    else stringBuilder.Append("N");
                }
                stringBuilder.Append(Environment.NewLine);
            }
            return stringBuilder.ToString().TrimEnd();
        }

        public static string FormatMap(Map map, Rover rover)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (var y = 0; y < map.Height; y++)
            {
                for (var x = 0; x < map.Width; x++)
                {
                    var location = new Location(x, y);
                    var square = map.GetSquareAtLocation(location);
                    var areLocationsEqual = LocationsAreEqual(square.Location, rover.Location);
                    if (square.HasObstacle()) 
                        stringBuilder.Append("O");
                    if (!square.HasObstacle() && areLocationsEqual) 
                        stringBuilder.Append("R");
                    if (!square.HasObstacle() && !areLocationsEqual) 
                        stringBuilder.Append("N");
                }
                stringBuilder.Append(Environment.NewLine);
            }
            return stringBuilder.ToString().TrimEnd();
        }

        private static bool LocationsAreEqual(Location location1, Location location2)
        {
            if (location1.X == location2.X && location1.Y == location2.Y) return true;
            return false;
        }
    }
}