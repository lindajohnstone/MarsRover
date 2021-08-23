using System;
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
        public void Read_ReturnString_GivenFileInput(string path, params string[] inputs)
        {
            var expected = String.Join(Environment.NewLine, inputs);

            var result = _fileInput.Read(path);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("TestFiles/testFile1.txt")]
        [InlineData("TestFiles/testFile2.txt")]
        [InlineData("TestFiles/testFile3.txt")]
        [InlineData("TestFiles/testFile4.txt")]
        public void FileExists_ReturnTrue_GivenValidFilePath(string path)
        {
            var result = _fileInput.FileExists(path);

            Assert.True(result);
        }

        [Theory]
        [InlineData("TestFiles/testFile.txt")]
        [InlineData("TestFile/testFile2.rtf")]
        [InlineData("TestFiles/testFile3")]
        [InlineData("TestFiles/Test/testFile4.txt")]
        public void FileExists_ReturnFalse_GivenInvalidFilePath(string path)
        {
            var result = _fileInput.FileExists(path);

            Assert.False(result);
        }
    }
}
