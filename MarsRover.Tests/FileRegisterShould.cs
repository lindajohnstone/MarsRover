using System;
using FluentAssertions;
using Xunit;

namespace MarsRover.Tests
{
    public class FileRegisterShould
    {
        private readonly FileRegister _fileRegister;

        public FileRegisterShould()
        {
            _fileRegister = new FileRegister();
        }

        [Fact]
        public void GetFiles_ReturnsValidFiles_GivenDirectoryAndSpecifier()
        {
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

            var result = _fileRegister.GetFiles(directory, specifier);

            result.Should().BeEquivalentTo(expectedFileRegister);
        }

        [Fact]
        public void DirectoryExists_ReturnsTrue_GivenValidDirectory()
        {
            var directory = "TestFiles";

            var result = _fileRegister.DirectoryExists(directory);

            result.Should().BeTrue();
        }

        [Fact]
        public void DirectoryExists_ReturnsFalse_GivenInvalidDirectory()
        {
            var directory = "test";

            var result = _fileRegister.DirectoryExists(directory);

            result.Should().BeFalse();
        }
    }
}
