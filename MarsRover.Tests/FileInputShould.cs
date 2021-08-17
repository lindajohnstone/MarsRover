using System;
using Xunit;

namespace MarsRover.Tests
{
    public class FileInputShould
    {
        [Theory]
        [InlineData("ONNN\nNNNN\nNNNN", "TestFiles/testFile1.txt")]
        [InlineData("ONNNNNNNNNNN\nONNNNNNONNNN\nONNNNNNNNNNN\nONNNNNNNNNNN\nONNNNNNNNNNN\nONNNNNNNNNNN\nONNNNNNNNNNN\nONNNNNNNNNNN", "TestFiles/testFile2.txt")]
        [InlineData("ONNNNNNN\nNNNNONNN\nNNNNNNNN", "TestFiles/testFile3.txt")]
        [InlineData("ONNNNNNN\nNNNNONNN\nNNNNONNO\nNNNNONNN\nNNNNNNNN", "TestFiles/testFile4.txt")]
        public void ReturnString_GivenFileInput(string expected, string path)
        {
            var input = new FileInput();

            var result = input.Read(path);

            Assert.Equal(expected, result);
        }
    }
}