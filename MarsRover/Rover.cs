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
            if (Direction == Direction.North) return Direction.West;
            if (Direction == Direction.South) return Direction.East;
            if (Direction == Direction.West) return Direction.South;
            if (Direction == Direction.East) return Direction.North;
            return Direction.None;
        }
    }
}
