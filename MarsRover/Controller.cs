using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Controller
    {
        IInput _input;

        IOutput _output;

        Generator _generator;

        public Controller(IInput input, IOutput output, Generator generator)
        {
            _input = input;
            _output = output;
            _generator = generator;
        }

        public void Run()
        {
            _generator.Setup();
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
            var width = _generator.Map.Width;
            var height = _generator.Map.Height;
            foreach (var command in commands)
            {
                if (command == Command.Forward || command == Command.Backward)
                {
                    var targetLocation = _generator.Rover.GetTargetLocation(command, width, height);
                    if (_generator.Map.HasObstacle(targetLocation))
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
            _generator.Rover.ExecuteCommand(command, width, height); // ControllerShould.Run_ReturnsMapOutput_GivenRoverCommandsThatResultInNoObstacle throws a null error here
            _output.WriteLine(OutputFormatter.FormatMap(_generator.Map, _generator.Rover));
            _output.WriteLine(Environment.NewLine);
        }
    }
}
