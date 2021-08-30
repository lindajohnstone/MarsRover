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
        public void Setup_ReturnsRoverLocationAndDirection_GivenValidMapAndRoverData()
        {
            var mockInput = new Mock<IInput>();
            mockInput.SetupSequence(_ => _.Read())
                .Returns("../TestFiles/validFile1.txt")
                .Returns("N")
                .Returns("2,0");
            var output = new StubOutput();
            var mockMapInput = new Mock<IMapInput>();
            mockMapInput.Setup(_ => _.Read("../TestFiles/validFile1.txt"))
                .Returns("ONNN\nNNNN\nNNNN");
            mockMapInput.Setup(_ => _.FileExists("../TestFiles/validFile1.txt"))
                .Returns(true);
            var controller = new Controller(mockInput.Object, output, mockMapInput.Object); 

            controller.Setup(); 

            controller.Rover.Direction.Should().Be(Direction.North);
            controller.Rover.Location.X.Should().Be(2);
            controller.Rover.Location.Y.Should().Be(0);
        }
    }
}
