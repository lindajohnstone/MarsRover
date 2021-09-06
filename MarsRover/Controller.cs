using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Controller
    {
        IInput _input;

        IOutput _output;

        IMapInput _mapInput;

        public Map Map { get; private set; }

        public Rover Rover { get; private set; }

        public Controller(IInput input, IOutput output, IMapInput mapInput)
        {
            _input = input;
            _output = output;
            _mapInput = mapInput;
        }

        public void Run()
        {
            Setup();
            _output.WriteLine(Messages.RoverCommands);
            var input = _input.ReadLine();
            while (input != "q")
            {
                if (Map.HasObstacle(Rover.Location))
                {
                    _output.WriteLine(Messages.RoverReportsObstacle); // TODO: This works if enter is pressed when asked for input if line 164 commented out
                    return;
                }
                var commands = GetCommands(input);
                FollowCommands(commands);
                _output.WriteLine(Environment.NewLine);
                _output.WriteLine(Messages.RoverCommands);
                _output.WriteLine(Messages.Quit);
                input = _input.ReadLine();
            }
            _output.WriteLine(Messages.End);
        }

        private void Setup()
        {
            _output.WriteLine(Messages.Title);
            InitialiseMap();
            _output.WriteLine(OutputFormatter.FormatMap(Map));
            InitialiseRover();
            _output.WriteLine(OutputFormatter.FormatMap(Map, Rover));
        }

        private void InitialiseMap()
        {
            _output.WriteLine(Messages.RequestMapInput);
            var filePath = GetValidFilePath();
            var input = _mapInput.Read(filePath);
            var isValidMap = Validator.IsValidMap(input);
            while (!isValidMap)
            {
                _output.WriteLine(Messages.InvalidInput);
                _output.WriteLine(Messages.RequestMapInput);
                input = _input.ReadLine();
                isValidMap = Validator.IsValidMap(input);
            }
            Map = MapParser.ParseMap(input);
        }

        private string GetValidFilePath() 
        {
            var filePath = _input.ReadLine();
            var fileExists = _mapInput.FileExists(filePath);
            while (!fileExists)
            {
                _output.WriteLine(Messages.InvalidInput);
                _output.WriteLine(Messages.RequestMapInput);
                filePath = _input.ReadLine();
                fileExists = _mapInput.FileExists(filePath);
            }
            return filePath;
        }

        private void InitialiseRover()
        {
            var direction = InitialiseDirection();
            var location = InitialiseLocation();
            Rover = new Rover(direction, location.X, location.Y);
        }

        private Direction InitialiseDirection()
        {
            _output.WriteLine(Messages.RoverStartDirection);
            var input = _input.ReadLine();
            var isValidDirection = Validator.IsValidDirection(input);
            while (!isValidDirection)
            {
                _output.WriteLine(Messages.InvalidInput);
                _output.WriteLine(Messages.RoverStartDirection);
                input = _input.ReadLine();
                isValidDirection = Validator.IsValidDirection(input);
            }
            var direction = InputParser.ParseDirection(input);
            return direction;
        }

        private Location InitialiseLocation()
        {
            _output.WriteLine(Messages.RoverStartLocation);
            var input = _input.ReadLine();
            var isValidLocation = Validator.IsValidLocation(input, Map.Width, Map.Height);
            while(!isValidLocation)
            {
                _output.WriteLine(Messages.InvalidInput);
                _output.WriteLine(Messages.RoverStartLocation);
                input = _input.ReadLine();
                isValidLocation = Validator.IsValidLocation(input, Map.Width, Map.Height);
            }
            var location = InputParser.ParseLocation(input);

            if (Map.HasObstacle(location)) 
            {
                _output.WriteLine(Messages.InvalidLocation);
                InitialiseLocation();
            }
            return location;
        }

        private List<Command> GetCommands(string commands) 
        {
            var areAllCommandsValid = Validator.AreCommandsValid(commands);
            while (!areAllCommandsValid)
            {
                _output.WriteLine(Messages.InvalidInput);
                _output.WriteLine(Messages.RoverCommands);
                commands = _input.ReadLine();
                areAllCommandsValid = Validator.AreCommandsValid(commands);
            }
            return InputParser.ParseCommands(commands);
        }
        /*
            TODO: if (Map.HasObstacle(Rover.Location)) == true, Rover.Location is on a Square containing an Obstacle
            Therefore, cannot move...
            How to revert command? - or find a way to check if the Square has an Obstacle before moving to it
            Store temp location, check if there is an obstacle, if not, move to that location - how??
            Temp solution = MoveRoverToPreviousLocation
        */
        private void FollowCommands(List<Command> commands)
        {
            var currentLocation = Rover.Location;
            foreach (var command in commands)
            {
                Rover.ExecuteCommand(command, Map.Width, Map.Height);
                if (!Map.HasObstacle(Rover.Location))
                {
                    _output.WriteLine(OutputFormatter.FormatMap(Map, Rover));
                    _output.WriteLine(Environment.NewLine);
                }
                else
                {
                    _output.WriteLine(string.Format(Messages.RoverReportsObstacle, Rover.Location.X, Rover.Location.Y));
                    // MoveRoverToPreviousLocation(command);
                    Rover.SetLocation(currentLocation);
                    return;
                }
            }
        }

        private void MoveRoverToPreviousLocation(Command command)
        {
            if (command == Command.Backward) Rover.ExecuteCommand(Command.Backward, Map.Width, Map.Height);
            else Rover.ExecuteCommand(Command.Backward, Map.Width, Map.Height);
        }
    }
}
