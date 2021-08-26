using System;
using FluentAssertions;
using Xunit;

namespace MarsRover.Tests
{
    public class FileInputShould
    {
        FileInput _fileInput;
        public FileInputShould()
        {
            _fileInput = new FileInput();
        }
        [Theory]
        [MemberData(nameof(FileInputShouldTestData.FileInputTestData), MemberType = typeof(FileInputShouldTestData))]
        public void Read_ReturnsString_GivenFileInput(string path, params string[] inputs)
        {
            var expectedString = String.Join(Environment.NewLine, inputs);

            var result = _fileInput.Read(path);

            result.Should().BeEquivalentTo(expectedString);
        }

        [Theory]
        [InlineData("TestFiles/validFile1.txt")]
        [InlineData("TestFiles/validFile2.txt")]
        [InlineData("TestFiles/validFile3.txt")]
        [InlineData("TestFiles/validFile4.txt")]
        public void FileExists_ReturnsTrue_GivenValidFilePath(string path)
        {
            var result = _fileInput.FileExists(path);

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("TestFiles/fileDoesNotExist.txt")]
        [InlineData("TestFile/badExtension.rtf")]
        [InlineData("TestFiles/noExtension")]
        [InlineData("TestFiles/Test/badFolder.txt")]
        public void FileExists_ReturnsFalse_GivenInvalidFilePath(string path)
        {
            var result = _fileInput.FileExists(path);

            result.Should().BeFalse();
        }
    }
}
