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
            if (command == Command.TurnLeft && Direction == Direction.North) return Direction.West;
            if (command == Command.TurnLeft && Direction == Direction.South) return Direction.East;
            if (command == Command.TurnLeft && Direction == Direction.West) return Direction.South;
            if (command == Command.TurnLeft && Direction == Direction.East) return Direction.North;
            if (command == Command.TurnRight && Direction == Direction.North) return Direction.East;
            if (command == Command.TurnRight && Direction == Direction.South) return Direction.West;
            if (command == Command.TurnRight && Direction == Direction.West) return Direction.North;
            if (command == Command.TurnRight && Direction == Direction.East) return Direction.South;
            return Direction.None;
        }
    }
}
