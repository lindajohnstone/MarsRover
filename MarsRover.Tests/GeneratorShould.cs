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
                .Returns("1")
                .Returns("TestFiles/validFile1.txt")
                .Returns("N")
                .Returns("2,0");
            var fileMapInput = new FileMapInput();
            var output = new StubOutput();
            var mapGenerator = new MapGenerator(mockInput.Object, output, fileMapInput);
            var generator = new Generator(mockInput.Object, output, mapGenerator, It.IsAny<AutoMapGenerator>());
            var expectedString = "🟫⬜️⏫⬜️\n⬜️⬜️⬜️⬜️\n⬜️⬜️⬜️⬜️";

            generator.Setup();
            
            output.GetLastOutput().Should().BeEquivalentTo(expectedString);
        }

        [Fact]
        public void Setup_ReturnsMapString_GivenValidRoverAndAutoMapData()
        {
            var fileMapInput = new FileMapInput();
            var output = new StubOutput();
            var mockInput = new Mock<IInput>();
            mockInput.SetupSequence(i => i.ReadLine())
                .Returns("2")
                .Returns("TestFiles")
                .Returns("N")
                .Returns("2,0")
                .Returns("lfrlb")
                .Returns("q");
            var fileRegister = new FileRegister();
            var mockRandomGenerator = new Mock<IRandomGenerator>();
            mockRandomGenerator.Setup(m => m.RandomString(It.IsAny<string[]>()))
                .Returns("TestFiles/validFile1.txt");
            var map = new AutoMapGenerator(mockInput.Object, fileMapInput, fileRegister, mockRandomGenerator.Object);
            var generator = new Generator(mockInput.Object, output, It.IsAny<MapGenerator>(), map);
            var expectedString = "🟫⬜️⏫⬜️\n⬜️⬜️⬜️⬜️\n⬜️⬜️⬜️⬜️";

            generator.Setup();

            output.GetLastOutput().Should().BeEquivalentTo(expectedString);
        }
    }
}
