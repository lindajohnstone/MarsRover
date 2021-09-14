using System;

namespace MarsRover
{
    public class Generator
    {
        private readonly IInput _input;
        private readonly IMapInput _mapInput;

        private readonly IOutput _output;

        public Map Map { get; private set; }

        public Rover Rover { get; set; }

        public Generator(IInput input, IOutput output, IMapInput fileMapInput)
        {
            _input = input;
            _output = output;
            _mapInput = fileMapInput;
        }

        public void Setup()
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
            while (!isValidLocation)
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
                location = InitialiseLocation();
            }
            return location;
        }        
    }
}
