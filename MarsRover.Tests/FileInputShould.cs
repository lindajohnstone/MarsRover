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
        public void Read_ReturnsString_GivenFileInput(string path, params string[] inputs)
        {
            var expected = String.Join(Environment.NewLine, inputs);

            var result = _fileInput.Read(path);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("TestFiles/valid-file-1.txt")]
        [InlineData("TestFiles/valid-file-2.txt")]
        [InlineData("TestFiles/valid-file-3.txt")]
        [InlineData("TestFiles/valid-file-4.txt")]
        public void FileExists_ReturnsTrue_GivenValidFilePath(string path)
        {
            var result = _fileInput.FileExists(path);

            Assert.True(result);
        }

        [Theory]
        [InlineData("TestFiles/file-does-no-exist.txt")]
        [InlineData("TestFile/bad-extension.rtf")]
        [InlineData("TestFiles/no-extension")]
        [InlineData("TestFiles/Test/bad-folder.txt")]
        public void FileExists_ReturnsFalse_GivenInvalidFilePath(string path)
        {
            var result = _fileInput.FileExists(path);

            Assert.False(result);
        }
    }
}
