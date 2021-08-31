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

        public void Setup()
        {
            _output.WriteLine(Messages.Title);
            InitialiseMap();
            _output.WriteLine(OutputFormatter.DisplayMap(Map));
            InitialiseRover();
            _output.WriteLine(OutputFormatter.DisplayMap(Map, Rover));
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

        private string GetValidFilePath() // TODO: what is method doing? name??
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
                _output.WriteLine(Messages.InvalidInput);
                InitialiseLocation();
            }
            return location;
        }
        // user asked for string of commands
        // user enters string of commands
        // commands are validated
        // commands are parsed 
        // rover follows each command
        // Move logic:
        // 1/ GetTargetLocation to determine where Rover should Move to
        // 2a/ use Map.GetSquareAtLocation in order to find Square -  ?? HasObstacle - Controller
        // 2b/ use Map.HasObstacle on the square to check if there is an obstacle - Controller
        // 3/ if no obstacle, set Rover.Location to the location of that square - ?? Move
        // if there is an obstacle, Rover.Location remains the same
        // Rover reports to user re obstacle
        public void Run()
        {
            _output.WriteLine(Messages.RoverCommands);
            var commandString = _input.ReadLine();
            var areAllCommandsValid = Validator.AreCommandsValid(commandString);
            while(!areAllCommandsValid)
            {
                _output.WriteLine(Messages.InvalidInput);
                _output.WriteLine(Messages.RoverCommands);
                commandString = _input.ReadLine();
                areAllCommandsValid = Validator.AreCommandsValid(commandString);
            }
            var commands = InputParser.ParseCommands(commandString);
        }
    }
}
