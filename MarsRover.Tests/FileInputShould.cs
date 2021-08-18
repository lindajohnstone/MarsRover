using System;
using Xunit;

namespace MarsRover.Tests
{
    public class FileInputShould
    {
        [Theory]
        [MemberData(nameof(FileInputShouldTestData.FileInputTestData), MemberType = typeof(FileInputShouldTestData))]
        public void ReturnString_GivenFileInput(string path, params string[] inputs)
        {
            var expected = String.Join(Environment.NewLine, inputs);
            var input = new FileInput();

            var result = input.Read(path);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("TestFiles/testFile1.txt")]
        [InlineData("TestFiles/testFile2.txt")]
        [InlineData("TestFiles/testFile3.txt")]
        [InlineData("TestFiles/testFile4.txt")]
        public void ReturnFilePath_GivenValidFilePath(string path)
        {
            var input = new FileInput();
            var expected = path;

            var result = input.FileExists(path);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("TestFiles/testFile.txt")]
        [InlineData("TestFile/testFile2.rtf")]
        [InlineData("TestFiles/testFile3")]
        [InlineData("TestFiles/Test/testFile4.txt")]
        public void ReturnString_GivenInvalidFilePath(string path)
        {
            var input = new FileInput();
            var expected = "File does not exist.";

            var result = input.FileExists(path);

            Assert.Equal(expected, result);
        }
    }
}