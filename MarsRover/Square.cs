namespace MarsRover
{
    public class Square
    {
        public Square(SquareContent content, int x, int y)
        {
            Content = content;
            Location = new Location(x, y);
        }
        public SquareContent Content { get; private set; }

        public Location Location { get; private set; }
    }
}