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
        public void Setup_ReturnsMapOutput_GivenValidMapAndRoverData()
        {
            var mockInput = new Mock<IInput>();
            mockInput.SetupSequence(_ => _.ReadLine())
                .Returns("TestFiles/validFile1.txt")
                .Returns("N")
                .Returns("2,0");
            var output = new StubOutput();
            var fileMapInput = new FileMapInput();
            var controller = new Controller(mockInput.Object, output, fileMapInput); 
            var expectedString = "🟫⬜️⏫⬜️\n⬜️⬜️⬜️⬜️\n⬜️⬜️⬜️⬜️";

            controller.Setup();

            output.GetLastOutput().Should().BeEquivalentTo(expectedString);
        }

        [Fact]
        public void Setup_ReturnsMapOutput_GivenValidRoverAndInvalidAndValidMapData()
        {
            var mockInput = new Mock<IInput>();
            mockInput.SetupSequence(_ => _.ReadLine())
                .Returns("TestFiles/invalidFile1.txt")
                .Returns("TestFiles/validFile1.txt")
                .Returns("N")
                .Returns("2,0");
            var output = new StubOutput();
            var fileMapInput = new FileMapInput();
            var expectedString = "🟫⬜️⏫⬜️\n⬜️⬜️⬜️⬜️\n⬜️⬜️⬜️⬜️";
            var controller = new Controller(mockInput.Object, output, fileMapInput);

            controller.Setup();

            output.GetLastOutput().Should().BeEquivalentTo(expectedString);
        }

        [Fact]
        public void Setup_ReturnsMapOutput_GivenValidMapAndInvalidAndValidMapRoverDirection()
        {
            var mockInput = new Mock<IInput>();
            mockInput.SetupSequence(_ => _.ReadLine())
                .Returns("TestFiles/validFile1.txt")
                .Returns("k")
                .Returns("N")
                .Returns("2,0");
            var output = new StubOutput();
            var fileMapInput = new FileMapInput();
            var expectedString = "🟫⬜️⏫⬜️\n⬜️⬜️⬜️⬜️\n⬜️⬜️⬜️⬜️";
            var controller = new Controller(mockInput.Object, output, fileMapInput);

            controller.Setup();

            output.GetLastOutput().Should().BeEquivalentTo(expectedString);
        }

        [Fact]
        public void Setup_ReturnsMapOutput_GivenValidMapAndInvalidAndValidRoverLocation()
        {
            var mockInput = new Mock<IInput>();
            mockInput.SetupSequence(_ => _.ReadLine())
                .Returns("TestFiles/validFile1.txt")
                .Returns("N")
                .Returns("1.0")
                .Returns("2,0");
            var output = new StubOutput();
            var fileMapInput = new FileMapInput();
            var expectedString = "🟫⬜️⏫⬜️\n⬜️⬜️⬜️⬜️\n⬜️⬜️⬜️⬜️";
            var controller = new Controller(mockInput.Object, output, fileMapInput);

            controller.Setup();

            output.GetLastOutput().Should().BeEquivalentTo(expectedString);
        }

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

            controller.Setup();
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

            controller.Setup();
            controller.Run();

            output.GetLastOutput().Should().BeEquivalentTo(expectedString);
        }
    }
}
