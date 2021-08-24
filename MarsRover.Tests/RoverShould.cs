using System;
using FluentAssertions;
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

            result.Should().Equals(expected);
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

            result.Should().Equals(expected);
        }

        [Theory]
        [InlineData(Direction.North, 2, 1)]
        [InlineData(Direction.South, 2, 3)]
        [InlineData(Direction.West, 1, 2)]
        [InlineData(Direction.East, 3, 2)]
        public void Move_ReturnsLocation_GivenCommandForward(Direction direction, int x, int y)
        {
            var expected = new Location(x, y);
            var command = Command.Forward;
            var rover = new Rover(direction, 2, 2);

            var result = rover.GetTargetLocation(command);

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(Direction.North, 2, 3)]
        [InlineData(Direction.South, 2, 1)]
        [InlineData(Direction.West, 3, 2)]
        [InlineData(Direction.East, 1, 2)]
        public void Move_ReturnEndLocation_GivenCommandBackward(Direction direction, int x, int y)
        {
            var expectedEndLocation = new Location(x, y);
            var command = Command.Backward;
            var rover = new Rover(direction, 2, 2);

            var result = rover.GetTargetLocation(command);

            result.Should().BeEquivalentTo(expectedEndLocation);
        }
    }
}
