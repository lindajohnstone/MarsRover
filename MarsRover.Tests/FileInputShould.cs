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
    }
}