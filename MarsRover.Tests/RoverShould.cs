using FluentAssertions;
using Moq;
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
        public void ExecuteCommand_ReturnsDirection_GivenCommandTurnLeft(Direction direction, Direction expectedDirection)
        {
            var command = Command.TurnLeft;
            var rover = new Rover(direction, 2, 2);

            rover.ExecuteCommand(command, It.IsAny<int>(), It.IsAny<int>());

            rover.Direction.Should().Be(expectedDirection);
        }

        [Theory]
        [InlineData(Direction.North, Direction.East)]
        [InlineData(Direction.South, Direction.West)]
        [InlineData(Direction.West, Direction.North)]
        [InlineData(Direction.East, Direction.South)]
        public void ExecuteCommand_ReturnsDirection_GivenCommandTurnRight(Direction direction, Direction expectedDirection)
        {
            var command = Command.TurnRight;
            var rover = new Rover(direction, 2, 2);

            rover.ExecuteCommand(command, It.IsAny<int>(), It.IsAny<int>());

            rover.Direction.Should().Be(expectedDirection);
        }

        [Theory]
        [InlineData(Direction.North, 2, 1)]
        [InlineData(Direction.South, 2, 3)]
        [InlineData(Direction.West, 1, 2)]
        [InlineData(Direction.East, 3, 2)]
        public void ExecuteCommand_ReturnsLocation_GivenCommandForwardAndNonBoundaryCoordinates(Direction direction, int x, int y)
        {
            var expectedEndLocation = new Location(x, y);
            var command = Command.Forward;
            var rover = new Rover(direction, 2, 2);

            rover.ExecuteCommand(command, It.IsAny<int>(), It.IsAny<int>());

            rover.Location.Should().BeEquivalentTo(expectedEndLocation);
        }

        [Theory]
        [InlineData(Direction.North, 2, 3)]
        [InlineData(Direction.South, 2, 1)]
        [InlineData(Direction.West, 3, 2)]
        [InlineData(Direction.East, 1, 2)]
        public void ExecuteCommand_ReturnEndLocation_GivenCommandBackwardAndNonBoundaryCoordinates(Direction direction, int x, int y)
        {
            var expectedEndLocation = new Location(x, y);
            var command = Command.Backward;
            var rover = new Rover(direction, 2, 2);

            rover.ExecuteCommand(command, It.IsAny<int>(), It.IsAny<int>());

            rover.Location.Should().BeEquivalentTo(expectedEndLocation);
        }

        [Theory]
        [InlineData(Direction.West, 4, 3, 0, 3)]
        [InlineData(Direction.East, 0, 1, 4, 1)]
        [InlineData(Direction.North, 0, 3, 0, 0)]
        [InlineData(Direction.South, 0, 0, 0, 3)]
        public void ExecuteCommand_ReturnEndLocation_GivenCommandForwardAndBoundaryCoordinates(Direction direction, int x, int y, int x1, int y1)
        {
            var expectedEndLocation = new Location(x, y);
            var command = Command.Forward;
            var rover = new Rover(direction, x1, y1);

            rover.ExecuteCommand(command, 5, 4);

            rover.Location.Should().BeEquivalentTo(expectedEndLocation);
        }

        [Theory]
        [InlineData(Direction.West, 0, 1, 4, 1)]
        [InlineData(Direction.East, 4, 3, 0, 3)]
        [InlineData(Direction.North, 4, 0, 4, 3)]
        [InlineData(Direction.South, 2, 3, 2, 0)]
        public void ExecuteCommand_ReturnLocation_GivenCommandBackwardAndBoundaryCoordinates(Direction direction, int x, int y, int x1, int y1)
        {
            var expectedEndLocation = new Location(x, y);
            var command = Command.Backward;
            var rover = new Rover(direction, x1, y1);

            rover.ExecuteCommand(command, 5, 4);

            rover.Location.Should().BeEquivalentTo(expectedEndLocation);
        }

        [Theory]
        [InlineData(Command.Forward, Direction.South, 2, 3)]
        [InlineData(Command.Forward, Direction.North, 2, 1)]
        [InlineData(Command.Forward, Direction.East, 3, 2)]
        [InlineData(Command.Forward, Direction.West, 1, 2)]
        [InlineData(Command.Backward, Direction.South, 2, 1)]
        [InlineData(Command.Backward, Direction.North, 2, 3)]
        [InlineData(Command.Backward, Direction.East, 1, 2)]
        [InlineData(Command.Backward, Direction.West, 3, 2)]
        public void GetTargetLocation_ReturnLocation_GivenCommandAndBoundaryCoordinates(Command command, Direction direction, int x, int y)
        {
            var expectedLocation = new Location(x,y);
            var rover = new Rover(direction, 2, 2);

            var result = rover.GetTargetLocation(command, 5, 4);

            result.Should().BeEquivalentTo(expectedLocation);
        }
    }
}
