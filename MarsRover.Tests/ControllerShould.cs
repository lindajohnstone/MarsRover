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
                .Returns("TestFiles/validFile1.txt")
                .Returns("N")
                .Returns("2,0");
            var output = new StubOutput();
            var mockMapInput = new Mock<IMapInput>();
            mockMapInput.Setup(_ => _.Read("TestFiles/validfile1.txt"));
            var map = SetMap();
            var rover = new Rover(Direction.North, 2, 0);

            var controller = new Controller(mockInput.Object, output, mockMapInput.Object, map, rover); 

            controller.Setup(); // TODO: added this line & now test hangs. filepath is not valid (used debugger)

            rover.Direction.Should().Be(Direction.North);
            rover.Location.X.Should().Be(2);
            rover.Location.Y.Should().Be(0);
        }

        public static Map SetMap()
        {
            var width = 5;
            var height = 4;
            var squares = new List<Square>
            {
                new Square(SquareContent.Obstacle, 0, 0),
                new Square(SquareContent.None, 1, 0),
                new Square(SquareContent.None, 2, 0),
                new Square(SquareContent.None, 3, 0),
                new Square(SquareContent.None, 4, 0),
                new Square(SquareContent.None, 0, 1),
                new Square(SquareContent.None, 1, 1),
                new Square(SquareContent.None, 2, 1),
                new Square(SquareContent.None, 3, 1),
                new Square(SquareContent.Obstacle, 4, 1),
                new Square(SquareContent.None, 0, 2),
                new Square(SquareContent.None, 1, 2),
                new Square(SquareContent.Obstacle, 2, 2),
                new Square(SquareContent.None, 3, 2),
                new Square(SquareContent.None, 4, 2),
                new Square(SquareContent.None, 0, 3),
                new Square(SquareContent.None, 1, 3),
                new Square(SquareContent.Obstacle, 2, 3),
                new Square(SquareContent.None, 3, 3),
                new Square(SquareContent.None, 4, 3)
            };
            var map = new Map(width, height, squares);
            return map;
        }
    }
}
