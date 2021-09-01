using System;
using System.Collections.Generic;
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
                .Returns("lfrlb");
            var output = new StubOutput();
            var fileMapInput = new FileMapInput();
            var expectedString = "🟫⬜️⏪⬜️\n⬜️⬜️⬜️⬜️\n⬜️⬜️⬜️⬜️";
            var controller = new Controller(mockInput.Object, output, fileMapInput);

            controller.Run();

            output.GetLastOutput().Should().BeEquivalentTo(expectedString);
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
                .Returns("lfflb");
            var output = new StubOutput();
            var fileMapInput = new FileMapInput();
            var expectedString = "Rover says Rover can't move.";
            var controller = new Controller(mockInput.Object, output, fileMapInput);

            controller.Run();

            output.GetLastOutput().Should().BeEquivalentTo(expectedString);
        }
    }
}
