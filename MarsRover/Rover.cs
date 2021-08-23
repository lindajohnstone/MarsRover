namespace MarsRover
{
    public class Rover
    {
        // has a Direction & a Location 
        public Rover(Direction direction, int x, int y)
        {
            Direction = direction;
            Location = new Location(x, y);
        }

        public Direction Direction { get; private set; }

        public Location Location { get; private set; }
    }
}