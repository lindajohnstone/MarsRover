using System.Collections.Generic;
using Xunit;

namespace MarsRover.Tests
{
    public class InputParserShouldTestData
    {
        public static TheoryData<string, List<Command>> ParseCommandsTestData =
            new TheoryData<string, List<Command>>
            {
                {
                    "flfr",
                    new List<Command>
                    {
                        Command.Forward,
                        Command.TurnLeft,
                        Command.Forward,
                        Command.TurnRight
                    }
                },
                {
                    "blbr",
                    new List<Command>
                    {
                        Command.Backward,
                        Command.TurnLeft,
                        Command.Backward,
                        Command.TurnRight
                    }
                },
                {
                    "FRBR",
                    new List<Command>
                    {
                        Command.Forward,
                        Command.TurnRight,
                        Command.Backward,
                        Command.TurnRight
                    }
                },
                {
                    "flBr",
                    new List<Command>
                    {
                        Command.Forward,
                        Command.TurnLeft,
                        Command.Backward,
                        Command.TurnRight
                    }
                }
            };
    }
}
