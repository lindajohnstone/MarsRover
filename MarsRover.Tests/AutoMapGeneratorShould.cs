using System;
using FluentAssertions;
using Moq;
using Xunit;

namespace MarsRover.Tests
{
    public class AutoMapGeneratorShould
    {
        [Fact]
        public void Initialise_ReturnsMapOutput_GivenValidMapData() 
        // TODO: test is hanging (waiting for input??). not sure it understands the directory input
        // debug hangs too
        {
            var fileMapInput = new FileMapInput();
            var mockInput = new Mock<IInput>();
            mockInput.Setup(i => i.ReadLine())
                .Returns("TestFiles");
            var output = new StubOutput();
            var fileRegister = new FileRegister();
            var files = new string[]
            {
                "TestFiles/emptyFile.txt",
                "TestFiles/validFile1.txt",
                "TestFiles/validFile2.txt",
                "TestFiles/validFile3.txt",
                "TestFiles/validFile4.txt"
            };
            var mockRandomGenerator = new Mock<IRandomGenerator>();
            mockRandomGenerator.Setup(m => m.RandomString(files, files.Length))
                .Returns("TestFiles/validFile1.txt");
            var map = new AutoMapGenerator(mockInput.Object, output, fileMapInput, fileRegister, mockRandomGenerator.Object);
            var expectedString = "🟫⬜️⬜️⬜️\n⬜️⬜️⬜️⬜️\n⬜️⬜️⬜️⬜️";

            map.Initialise();

            output.GetLastOutput().Should().BeEquivalentTo(expectedString);
        }
    }
}