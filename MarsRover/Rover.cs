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

        public void DoThisCommand(Command command)
        {
            switch (command)
            {
                case Command.TurnLeft:
                    TurnLeft();
                    break;
                default:
                    return;
            }
        }
//^v<>
        private void TurnLeft()
        {
            Direction = Direction switch 
            {
                Direction.North => Direction.West,
                Direction.West => Direction.South,
                Direction.South => Direction.East,
                Direction.East => Direction.North,
                _ => Direction.None
            };
        }
        public Direction Turn(Command command) 
        {
            var turnLeft = command == Command.TurnLeft;
            var turnRight = command == Command.TurnRight;
            
            var north = Direction == Direction.North;
            var south = Direction == Direction.South;

            // var turnWest = Direction.West;
            if ((turnLeft && north) || (turnRight && south))
                return Direction.West;
           

            var turnEast = Direction.East;
            if ((turnRight && north) || (turnLeft && south)) return turnEast;

            var west = Direction == Direction.West;
            var east = Direction == Direction.East;

            var turnSouth = Direction.South;
            if ((turnLeft && west) || (turnRight && east)) return turnSouth;

            var turnNorth = Direction.North;
            if ((turnRight && west) || (turnLeft && east)) return turnNorth;

            return Direction.None;
            // if (command == Command.TurnLeft && Direction == Direction.North) return Direction.West;
            // if (command == Command.TurnLeft && Direction == Direction.South) return Direction.East;
            // if (command == Command.TurnLeft && Direction == Direction.West) return Direction.South;
            // if (command == Command.TurnLeft && Direction == Direction.East) return Direction.North;
            // if (command == Command.TurnRight && Direction == Direction.North) return Direction.East;
            // if (command == Command.TurnRight && Direction == Direction.South) return Direction.West;
            // if (command == Command.TurnRight && Direction == Direction.South) return Direction.West;
            // if (command == Command.TurnRight && Direction == Direction.West) return Direction.North;
            // if (command == Command.TurnRight && Direction == Direction.East) return Direction.South;
        }

        public Location GetTargetLocation(Command command) // TODO: refactor - including rename??
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
