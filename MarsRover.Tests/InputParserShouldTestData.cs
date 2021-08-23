using System.Collections.Generic;
using Xunit;

namespace MarsRover.Tests
{
    public class InputParserShouldTestData
    {
        public static TheoryData<string, List<Commands>> ParseCommandsTestData =
            new TheoryData<string, List<Commands>>
            {
                {
                    "flfr",
                    new List<Commands>
                    {
                        Commands.Forward,
                        Commands.TurnLeft,
                        Commands.Forward,
                        Commands.TurnRight
                    }
                },
                {
                    "blbr",
                    new List<Commands>
                    {
                        Commands.Backward,
                        Commands.TurnLeft,
                        Commands.Backward,
                        Commands.TurnRight
                    }
                },
                {
                    "FRBR",
                    new List<Commands>
                    {
                        Commands.Forward,
                        Commands.TurnRight,
                        Commands.Backward,
                        Commands.TurnRight
                    }
                }
            };
    }
}