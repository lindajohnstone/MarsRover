using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Xunit;

namespace MarsRover.Tests
{
    public class AutoMapGeneratorShould
    {
        [Fact]
        public void Initialise_ReturnsMapOutput_GivenValidMapData() 
        {
            var fileMapInput = new FileMapInput();
            var mockInput = new Mock<IInput>();
            mockInput.Setup(i => i.ReadLine())
                .Returns("TestFiles");
            var fileRegister = new FileRegister();
            var mockRandomGenerator = new Mock<IRandomGenerator>();
            mockRandomGenerator.Setup(m => m.RandomString(It.IsAny<string[]>()))
                .Returns("TestFiles/validFile1.txt");
            var map = new AutoMapGenerator(mockInput.Object, fileMapInput, fileRegister, mockRandomGenerator.Object);
            var squares = new List<Square>
            {
                new Square(SquareContent.Obstacle, 0, 0),
                new Square(SquareContent.None, 1, 0),
                new Square(SquareContent.None, 2, 0),
                new Square(SquareContent.None, 3, 0),
                new Square(SquareContent.None, 0, 1),
                new Square(SquareContent.None, 1, 1),
                new Square(SquareContent.None, 2, 1),
                new Square(SquareContent.None, 3, 1),
                new Square(SquareContent.None, 0, 2),
                new Square(SquareContent.None, 1, 2),
                new Square(SquareContent.None, 2, 2),
                new Square(SquareContent.None, 3, 2)
            };
            var expectedMap = new Map(4, 3, squares);

            var result = map.Initialise();

            result.Should().BeEquivalentTo(expectedMap);
        }
    }
}
