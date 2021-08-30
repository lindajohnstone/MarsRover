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

        /*
            Setup:
                1/ ask for fileinput
                2/ does file exist?
                if file exists:
                    validate the file
                    if not
                        keep asking if file is not valid
                    if valid
                        parse the map
                        DisplayMap(map)
                ask for rover direction from user
                    validate direction
                    if not valid
                        keep asking for valid direction
                    if valid
                    ask for rover location from user
                        validate location
                        if not valid
                            keep asking for valid location
                        if valid
                            is there an obstacle?
                            yes - repeat asking for location input
                            no - create rover
                            DisplayMap(map, rover)
                ** test to return map with rover when setup complete
        */

        // Move logic:
        // 1/ GetTargetLocation to determine where Rover should Move to
        // 2a/ use Map.GetSquareAtLocation in order to find Square -  ?? HasObstacle - Controller
        // 2b/ use Map.HasObstacle on the square to check if there is an obstacle - Controller
        // 3/ if no obstacle, set Rover.Location to the location of that square - ?? Move
        // if there is an obstacle, Rover.Location remains the same

        public void Setup()
        {
            _output.WriteLine(Messages.Title);
            Map = InitialiseMap();
            _output.WriteLine(OutputFormatter.DisplayMap(Map));
            Rover = InitialiseRover();
            _output.WriteLine(OutputFormatter.DisplayMap(Map, Rover));
        }

        private Map InitialiseMap()
        {
            _output.WriteLine(Messages.RequestMapInput);
            var filePath = _input.Read(); 
            var fileExists = _mapInput.FileExists(filePath); // TODO: file doesn't exist
            while(!fileExists)
            {
                _output.WriteLine(Messages.InvalidInput);
                _output.WriteLine(Messages.RequestMapInput);
                filePath = _input.Read(); 
                fileExists = _mapInput.FileExists(filePath);
            }
            var input = _mapInput.Read(filePath);
            var isValidMap = Validator.IsValidMap(input);
            while (!isValidMap)
            {
                _output.WriteLine(Messages.InvalidInput);
                _output.WriteLine(Messages.RequestMapInput);
                input = _input.Read();
                isValidMap = Validator.IsValidMap(input);
            }
            return Map = MapParser.ParseMap(input);
        }

        private Rover InitialiseRover()
        {
            var direction = InitialiseDirection();
            var location = InitialiseLocation();
            return Rover = new Rover(direction, location.X, location.Y);
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
            var isValidLocation = Validator.IsValidLocation(input, Map.Width, Map.Height);
            while(!isValidLocation)
            {
                _output.WriteLine(Messages.InvalidInput);
                _output.WriteLine(Messages.RoverStartLocation);
                input = _input.Read();
                isValidLocation = Validator.IsValidLocation(input, Map.Width, Map.Height);
            }
            var location = InputParser.ParseLocation(input);

            if (Map.HasObstacle(location)) 
            {
                _output.WriteLine(Messages.InvalidInput);
                InitialiseLocation();
            }
            return location;
        }
    }
}
