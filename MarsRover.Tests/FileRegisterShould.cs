using System;
using FluentAssertions;
using Xunit;

namespace MarsRover.Tests
{
    public class FileRegisterShould
    {
        [Fact]
        public void GetFiles_ReturnsValidFiles_GivenDirectoryAndSpecifier()
        {
            var fileRegister = new FileRegister();
            var directory = "TestFiles";
            var specifier = "*.txt";
            var expectedFileRegister = new string[]
            {
                "TestFiles/emptyFile.txt",
                "TestFiles/validFile1.txt",
                "TestFiles/validFile2.txt",
                "TestFiles/validFile3.txt",
                "TestFiles/validFile4.txt"
            };

            var result = fileRegister.GetFiles(directory, specifier);

            result.Should().BeEquivalentTo(expectedFileRegister);
        }
    }
}
