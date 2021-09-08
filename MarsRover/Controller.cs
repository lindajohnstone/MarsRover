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
        
        private void FollowCommands(List<Command> commands)
        {
            var width = Map.Width;
            var height = Map.Height;
            foreach (var command in commands)
            {
                if (command == Command.Forward || command == Command.Backward)
                {
                    var targetLocation = Rover.GetTargetLocation(command, width, height);
                    if (Map.HasObstacle(targetLocation))
                    {
                        _output.WriteLine(string.Format(Messages.RoverReportsObstacle, targetLocation.X, targetLocation.Y));
                        return;
                    }
                }
                FollowCommand(width, height, command);
            }
        }

        private void FollowCommand(int width, int height, Command command)
        {
            Rover.ExecuteCommand(command, width, height);
            _output.WriteLine(OutputFormatter.FormatMap(Map, Rover));
            _output.WriteLine(Environment.NewLine);
        }
    }
}
