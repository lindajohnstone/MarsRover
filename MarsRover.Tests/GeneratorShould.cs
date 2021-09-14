using System;
using FluentAssertions;
using Moq;
using Xunit;

namespace MarsRover.Tests
{
    public class GeneratorShould
    {
        [Fact]
        public void Setup_ReturnsMapString_GivenValidRoverAndMapData()
        {
            var mockInput = new Mock<IInput>();
            mockInput.SetupSequence(i => i.ReadLine())
                .Returns("TestFiles/validFile1.txt")
                .Returns("N")
                .Returns("2,0");
            var fileMapInput = new FileMapInput();
            var output = new StubOutput();
            var generator = new Generator(mockInput.Object, output, fileMapInput);
            var expectedString = "🟫⬜️⏫⬜️\n⬜️⬜️⬜️⬜️\n⬜️⬜️⬜️⬜️";

            generator.Setup();
            
            output.GetLastOutput().Should().BeEquivalentTo(expectedString);
        }
    }
}
