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

        public void ExecuteCommand(Command command, int maxWidth, int maxHeight)
        {
            switch (command)
            {
                case Command.TurnLeft:
                    TurnLeft();
                    break;
                case Command.TurnRight:
                    TurnRight();
                    break;
                case Command.Forward:
                    MoveForward(maxWidth, maxHeight);
                    break;
                case Command.Backward:
                    MoveBackward(maxWidth, maxHeight);
                    break;
                default:
                    return;
            }
        }

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

        private void TurnRight()
        {
            Direction = Direction switch
            {
                Direction.North => Direction.East,
                Direction.East => Direction.South,
                Direction.South => Direction.West,
                Direction.West => Direction.North,
                _ => Direction.None
            };
        }
        
        private void MoveForward(int maxWidth, int maxHeight) 
        {
            Location = GetTargetLocation(Command.Forward, maxWidth, maxHeight);
        }

        private void MoveBackward(int maxWidth, int maxHeight)
        {
            Location = GetTargetLocation(Command.Backward, maxWidth, maxHeight);
        }

        public Location GetTargetLocation(Command command, int maxWidth, int maxHeight)
        {
            if (command == Command.Forward) return GetTargetLocationForward(maxWidth, maxHeight);
            return GetTargetLocationBackward(maxWidth, maxHeight);
        }

        private Location GetTargetLocationForward(int maxWidth, int maxHeight)
        {
            var x = Location.X;
            var y = Location.Y;
            var xLeft = x == 0 ? maxWidth - 1 : x - 1;
            var xRight = x == maxWidth - 1 ? 0 : x + 1;
            var yTop = y == 0 ? maxHeight - 1 : y - 1;
            var yBottom = y == maxHeight - 1 ? 0 : y + 1;
            return Direction switch
            {
                Direction.North => new Location(x, yTop),
                Direction.South => new Location(x, yBottom),
                Direction.West => new Location(xLeft, y),
                Direction.East => new Location(xRight, y),
                _ => new Location(x, y)
            };
        }

        private Location GetTargetLocationBackward(int maxWidth, int maxHeight)
        {
            var x = Location.X;
            var y = Location.Y;
            var xLeft = x == maxWidth - 1 ? 0 : x + 1;
            var xRight = x == 0 ? maxWidth - 1 : x - 1;
            var yTop = y == maxHeight - 1 ? 0 : y + 1;
            var yBottom = y == 0 ? maxHeight - 1 : y - 1;
            return Direction switch
            {
                Direction.North => new Location(x, yTop),
                Direction.South => new Location(x, yBottom),
                Direction.West => new Location(xLeft, y),
                Direction.East => new Location(xRight, y),
                _ => new Location(x, y)
            };
        }
    }
}
