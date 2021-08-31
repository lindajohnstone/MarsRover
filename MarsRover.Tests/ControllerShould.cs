using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Xunit;

namespace MarsRover.Tests
{
    public class ControllerShould
    {
        /*
            test for invalid file - verify how many times called?
            test for valid file
            test for invalid direction
            test for valid direction
            test for 
        */
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
            fileMapInput.Read("TestFiles/validFile1.txt");
            fileMapInput.FileExists("TestFiles/validFile1.txt");
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
            var filePath = "TestFiles/validFile1.txt";
            fileMapInput.Read(filePath);
            fileMapInput.FileExists(filePath);
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
            var filePath = "TestFiles/validFile1.txt";
            fileMapInput.Read(filePath);
            fileMapInput.FileExists(filePath);
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
            var filePath = "TestFiles/validFile1.txt";
            fileMapInput.Read(filePath);
            fileMapInput.FileExists(filePath);
            var controller = new Controller(mockInput.Object, output, fileMapInput);

            controller.Setup();

            output.GetLastOutput().Should().BeEquivalentTo(expectedString);
        }
    }
}
