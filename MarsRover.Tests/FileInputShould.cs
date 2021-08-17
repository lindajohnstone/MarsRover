using System;
using Xunit;

namespace MarsRover.Tests
{
    public class FileInputShould
    {
        [Theory]
        [InlineData("TestFiles/testFile1.txt", "ONNN", "NNNN", "NNNN")]
        [InlineData("TestFiles/testFile2.txt", "ONNNNNNNNNNN", "ONNNNNNONNNN", "ONNNNNNNNNNN", "ONNNNNNNNNNN", "ONNNNNNNNNNN", "ONNNNNNNNNNN", "ONNNNNNNNNNN", "ONNNNNNNNNNN")]
        [InlineData("TestFiles/testFile3.txt", "ONNNNNNN", "NNNNONNN", "NNNNNNNN")]
        [InlineData("TestFiles/testFile4.txt", "ONNNNNNN", "NNNNONNN", "NNNNONNO", "NNNNONNN", "NNNNNNNN")]
        public void ReturnString_GivenFileInput(string path, params string[] inputs)
        {
            var expected = String.Join(Environment.NewLine, inputs);
            var input = new FileInput();

            var result = input.Read(path);

            Assert.Equal(expected, result);
        }
    }
}