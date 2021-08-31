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
                .Returns("../TestFiles/validFile1.txt")
                .Returns("N")
                .Returns("2,0");
            var output = new StubOutput();
            // TODO: replacing mockMapInput with FileMapInput causes test & debugger to hang
            var mockMapInput = new Mock<IMapInput>(); 
            mockMapInput.Setup(_ => _.Read("../TestFiles/validFile1.txt"))
                .Returns("ONNN\nNNNN\nNNNN");
            mockMapInput.Setup(_ => _.FileExists("../TestFiles/validFile1.txt"))
                .Returns(true);
            var controller = new Controller(mockInput.Object, output, mockMapInput.Object); 
            var expectedString = "🟫⬜️⏫⬜️\n⬜️⬜️⬜️⬜️\n⬜️⬜️⬜️⬜️";

            controller.Setup();

            output.GetLastOutput().Should().BeEquivalentTo(expectedString);
        }

        [Fact]
        public void Setup_ReturnsMapOutput_GivenValidAndInvalidMapAndRoverData()
        {
            var input = new StubInput();
            var output = new StubOutput();
            var fileMapInput = new FileMapInput();
            var expectedString = "🟫⬜️⏫⬜️\n⬜️⬜️⬜️⬜️\n⬜️⬜️⬜️⬜️";
            input.GetReadLine("../TestFiles/validFile1.txt");
            input.GetReadLine("N");
            input.GetReadLine("2,0");
            fileMapInput.Read("../TestFiles/validFile1.txt");
            fileMapInput.FileExists("../TestFiles/validFile1.txt");
            var controller = new Controller(input, output, fileMapInput);

            controller.Setup();

            output.GetLastOutput().Should().BeEquivalentTo(expectedString);
        }
    }
}
