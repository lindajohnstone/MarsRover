using FluentAssertions;
using Moq;
using Xunit;

namespace MarsRover.Tests
{
    public class ControllerShould
    {
        [Fact]
        public void Run_ReturnsMapOutput_GivenRoverCommandsThatResultInNoObstacle()
        {
            var mockInput = new Mock<IInput>();
            mockInput.SetupSequence(_ => _.ReadLine())
                .Returns("TestFiles/validFile1.txt")
                .Returns("N")
                .Returns("1.0")
                .Returns("2,0")
                .Returns("lfrlb")
                .Returns("q");
            var output = new StubOutput();
            var fileMapInput = new FileMapInput();
            var expectedString = "🟫⬜️⏪⬜️\n⬜️⬜️⬜️⬜️\n⬜️⬜️⬜️⬜️";
            var controller = new Controller(mockInput.Object, output, fileMapInput);

            controller.Run();

            output.GetLastMapOutput().Should().BeEquivalentTo(expectedString);
        }

        [Fact]
        public void Run_ReturnsRoverReport_GivenRoverCommandsThatResultInAnObstacle()
        {
            var mockInput = new Mock<IInput>();
            mockInput.SetupSequence(_ => _.ReadLine())
                .Returns("TestFiles/validFile1.txt")
                .Returns("N")
                .Returns("1.0")
                .Returns("2,0")
                .Returns("lfflb")
                .Returns("q");
            var output = new StubOutput();
            var fileMapInput = new FileMapInput();
            var expectedString = "Rover can't move. Obstacle at 0,0.";
            var controller = new Controller(mockInput.Object, output, fileMapInput);

            controller.Run();

            output.OutputList.Should().Contain(expectedString);
        }
    }
}
