using FluentAssertions;
using Moq;
using Xunit;

namespace MarsRover.Tests
{
    public class ControllerShould
    {
        private readonly Controller _controller;
        private Mock<IInput> _mockInput;
        private readonly StubOutput _output;
        private readonly FileMapInput _fileMapInput;

        public ControllerShould()
        {
            _mockInput = new Mock<IInput>();
            _output = new StubOutput();
            _fileMapInput = new FileMapInput();
            _controller = new Controller(_mockInput.Object, _output, _fileMapInput);
        }
        [Fact]
        public void Run_ReturnsMapOutput_GivenRoverCommandsThatResultInNoObstacle()
        {
            _mockInput.SetupSequence(_ => _.ReadLine())
                .Returns("TestFiles/validFile1.txt")
                .Returns("N")
                .Returns("1.0")
                .Returns("2,0")
                .Returns("lfrlb")
                .Returns("q");
            var expectedString = "🟫⬜️⏪⬜️\n⬜️⬜️⬜️⬜️\n⬜️⬜️⬜️⬜️";
            
            _controller.Run();

            _output.GetLastMapOutput().Should().BeEquivalentTo(expectedString);
        }

        [Fact]
        public void Run_ReturnsRoverReport_GivenRoverCommandsThatResultInAnObstacle()
        {
            _mockInput.SetupSequence(i => i.ReadLine())
                .Returns("TestFiles/validFile1.txt")
                .Returns("N")
                .Returns("1.0")
                .Returns("1,0")
                .Returns("lfr")
                .Returns("q");
            var expectedString = "Rover can't move. Obstacle at 0,0.";

            _controller.Run();

            _output.OutputList.Should().Contain(expectedString);
        }

        [Fact]
        public void Run_ReturnsRoverReport_GivenRoverCommandsThatResultInAnObstacleAnd2ConsecutiveCommandsSame()
        {
            _mockInput.SetupSequence(i => i.ReadLine())
                .Returns("TestFiles/validFile1.txt")
                .Returns("N")
                .Returns("1.0")
                .Returns("2,0")
                .Returns("lff")
                .Returns("q");
            var expectedString = "Rover can't move. Obstacle at 0,0.";
            
            _controller.Run();

            _output.OutputList.Should().Contain(expectedString);
        }

        [Fact]
        public void Run_ReturnsRoverEndLocation_GivenMapAnd2SetsOfRoverCommands()
        {
            _mockInput.SetupSequence(i => i.ReadLine())
                .Returns("TestFiles/validFile1.txt")
                .Returns("N")
                .Returns("2,0")
                .Returns("lff")
                .Returns("rff")
                .Returns("q");
            var expectedLocation = new Location(1,1);

            _controller.Run();

            _controller.Rover.Location.Should().BeEquivalentTo(expectedLocation);
        }
    }
}
