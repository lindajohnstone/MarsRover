using System;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverShould
    {
        [Theory]
        [InlineData(Direction.North, Direction.West)]
        [InlineData(Direction.South, Direction.East)]
        [InlineData(Direction.West, Direction.South)]
        [InlineData(Direction.East, Direction.North)]
        public void Turn_ReturnsDirection_GivenCommandTurnLeft(Direction direction, Direction expected)
        {
            var command = Command.TurnLeft;
            var rover = new Rover(direction, 2, 2);

            var result = rover.Turn(command);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(Direction.North, Direction.East)]
        [InlineData(Direction.South, Direction.West)]
        [InlineData(Direction.West, Direction.North)]
        [InlineData(Direction.East, Direction.South)]
        public void Turn_ReturnsDirection_GivenCommandTurnRight(Direction direction, Direction expected)
        {
            var command = Command.TurnRight;
            var rover = new Rover(direction, 2, 2);

            var result = rover.Turn(command);

            Assert.Equal(expected, result);
        }
    }
}
