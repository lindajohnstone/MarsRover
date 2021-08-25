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

        public void ExecuteCommand(Command command)
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
                    MoveForward();
                    break;
                case Command.Backward:
                    MoveBackward();
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

        // Move logic:
        // 1/ GetTargetLocation to determine where Rover should Move to
        // 2a/ use Map.GetSquareAtLocation in order to find Square -  ?? HasObstacle - Controller
        // 2b/ use Map.HasObstacle on the square to check if there is an obstacle - Controller
        // 3/ if no obstacle, set Rover.Location to the location of that square - ?? Move
        // if there is an obstacle, Rover.Location remains the same

        
        private void MoveForward()
        {
            Location = Direction switch
            {
                Direction.North => new Location(Location.X, Location.Y - 1),
                Direction.South => new Location(Location.X, Location.Y + 1),
                Direction.West => new Location(Location.X - 1, Location.Y),
                Direction.East => new Location(Location.X + 1, Location.Y),
                _ => new Location(Location.X, Location.Y)
            };
        }

        private void MoveBackward()
        {
            Location = Direction switch
            {
                Direction.North => new Location(Location.X, Location.Y + 1),
                Direction.South => new Location(Location.X, Location.Y - 1),
                Direction.West => new Location(Location.X + 1, Location.Y),
                Direction.East => new Location(Location.X - 1, Location.Y),
                _ => new Location(Location.X, Location.Y)
            };
        }
    }
}
