using System;

namespace MarsRover
{
    public class Generator
    {
        // generates map & location
        IInput _input;
        IOutput _output;
        IMapInput _mapInput;
        Map _map;
        Rover _rover;

        public Generator(IInput input, IOutput output, IMapInput mapInput, Map map, Rover rover)
        {
            _input = input;
            _output = output;
            _mapInput = mapInput;
            _map = map;
            _rover = rover;
        }

        public void GenerateRover()
        {
            var direction = InitialiseDirection();
            var location = InitialiseLocation();
            _rover = new Rover(direction, location.X, location.Y);
        }

        private Direction InitialiseDirection()
        {
            _output.WriteLine(Messages.RoverStartDirection);
            var input = _input.Read();
            var isValidDirection = Validator.IsValidDirection(input);
            while (!isValidDirection)
            {
                _output.WriteLine(Messages.InvalidInput);
                _output.WriteLine(Messages.RoverStartDirection);
                input = _input.Read();
                isValidDirection = Validator.IsValidDirection(input);
            }
            var direction = InputParser.ParseDirection(input);
            return direction;
        }

        private Location InitialiseLocation()
        {
            _output.WriteLine(Messages.RoverStartLocation);
            var input = _input.Read();
            var isValidLocation = Validator.IsValidLocation(input, _map.Width, _map.Height);
            while (!isValidLocation)
            {
                _output.WriteLine(Messages.InvalidInput);
                _output.WriteLine(Messages.RoverStartLocation);
                input = _input.Read();
                isValidLocation = Validator.IsValidLocation(input, _map.Width, _map.Height);
            }
            var location = InputParser.ParseLocation(input);
            // need to check if location contains an obstacle
            if (_map.HasObstacle(location)) // TODO: is this the correct way to do this??
            {
                _output.WriteLine(Messages.InvalidInput);
                InitialiseLocation();
            }
            return location;
        }
    }
}