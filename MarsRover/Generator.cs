using System;

namespace MarsRover
{
    public class Generator
    {
        private readonly IInput _input;

        private readonly IOutput _output;

        private readonly MapGenerator _mapGenerator;
        private readonly AutoMapGenerator _autoMapGenerator;

        public Generator(IInput input, IOutput output, MapGenerator map, AutoMapGenerator autoMap)
        {
            _input = input;
            _output = output;
            _mapGenerator = map;
            _autoMapGenerator = autoMap;
        }

        public Map Map { get; private set; }

        public Rover Rover { get; set; }

        public void Setup()
        {
            _output.WriteLine(Messages.Title);
            _output.WriteLine(Messages.Choice);
            var choice = GetValidChoice();
            if (choice == "1") Map = _mapGenerator.Initialise();
            else Map = _autoMapGenerator.Initialise(); 
            _output.WriteLine(OutputFormatter.FormatMap(Map));
            InitialiseRover();
            _output.WriteLine(OutputFormatter.FormatMap(Map, Rover));
        }

        private string GetValidChoice()
        {
            var choice = _input.ReadLine();
            var isValidChoice = Validator.IsValidChoice(choice);
            while (!isValidChoice)
            {
                _output.WriteLine(Messages.InvalidInput);
                _output.WriteLine(Messages.Choice);
                choice = _input.ReadLine();
                isValidChoice = Validator.IsValidChoice(choice);
            }
            return choice;
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
