namespace MarsRover
{
    public class Messages
    {
        public const string Title = "Mars Rover";

        public const string RequestMapInput = "Enter a valid file path.";

        public const string InvalidInput = "Invalid input. Please try again.";

        public const string RoverStartDirection = "Enter the Direction the Rover is heading - N, S, E, W.";

        public const string RoverStartLocation = "Enter the starting location for the Rover as a number followed by a comma then a number (e.g. '0,0').";

        public const string RoverCommands = "Enter Rovers' commands as a string containing only the letters 'F', 'B', 'L', 'R'.";
        
        public const string InvalidLocation = "Rover cannot occupy that location as it contains an obstacle.";

        public const string RoverReportsObstacle = "Rover can't move. Obstacle at {0},{1}.";

        public const string Quit = "Or enter 'q' to quit.";

        public const string End = "Mars Rover has completed his mission.";
    }
}