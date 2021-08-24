using System;

namespace MarsRover
{
    public class Rover
    {
        // has a Direction & a Location 
        // Move - Forward/Backward
        // Turn - Left/Right
        public Rover(Direction direction, int x, int y)
        {
            Direction = direction;
            Location = new Location(x, y);
        }

        public Direction Direction { get; private set; }

        public Location Location { get; private set; }

        public Direction Turn(Command command) // TODO: talk at Mentor meeting about changing to switch expression
        {
            var turnLeft = command == Command.TurnLeft;
            var turnRight = command == Command.TurnRight;
            
            var north = Direction == Direction.North;
            var south = Direction == Direction.South;

            var turnWest = Direction.West;
            if ((turnLeft && north) || (turnRight && south)) return turnWest;

            var turnEast = Direction.East;
            if ((turnRight && north) || (turnLeft && south)) return turnEast;

            var west = Direction == Direction.West;
            var east = Direction == Direction.East;

            var turnSouth = Direction.South;
            if ((turnLeft && west) || (turnRight && east)) return turnSouth;

            var turnNorth = Direction.North;
            if ((turnRight && west) || (turnLeft && east)) return turnNorth;

            return Direction.None;
        }

        public Location Move(Command command) // TODO: refactor
        {
            if (command == Command.Forward && Direction == Direction.North) return new Location(Location.X, Location.Y - 1);
            if (command == Command.Forward && Direction == Direction.South) return new Location(Location.X, Location.Y + 1);
            if (command == Command.Forward && Direction == Direction.West) return new Location(Location.X - 1, Location.Y);
            if (command == Command.Forward && Direction == Direction.East) return new Location(Location.X + 1, Location.Y);
            if (command == Command.Backward && Direction == Direction.North) return new Location(Location.X, Location.Y + 1);
            if (command == Command.Backward && Direction == Direction.South) return new Location(Location.X, Location.Y - 1);
            if (command == Command.Backward && Direction == Direction.West) return new Location(Location.X + 1, Location.Y);
            if (command == Command.Backward && Direction == Direction.East) return new Location(Location.X - 1, Location.Y);
            return Location;
        }
    }
}
