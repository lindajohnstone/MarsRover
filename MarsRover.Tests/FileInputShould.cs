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

        [Fact]
        public void ReturnFilePath_GivenValidFilePath()
        {
            var input = new FileInput();
            var path = "TestFiles/testFile1.txt";
            var expected = path;

            var result = input.FileExists(path);

            Assert.Equal(expected, result);

        }
    }
}