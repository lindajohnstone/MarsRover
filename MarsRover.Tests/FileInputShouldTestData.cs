using Xunit;

namespace MarsRover.Tests
{
    public class FileInputShouldTestData
    {
        public static TheoryData<string, string[]> FileInputTestData =
            new TheoryData<string, string[]>
            {
                {
                    "TestFiles/testFile1.txt",
                    new string[]
                    {
                        "ONNN",
                        "NNNN",
                        "NNNN"
                    }
                },
                {
                    "TestFiles/testFile2.txt",
                    new string[]
                    {
                        "ONNNNNNNNNNN", 
                        "ONNNNNNONNNN", 
                        "ONNNNNNNNNNN", 
                        "ONNNNNNNNNNN", 
                        "ONNNNNNNNNNN", 
                        "ONNNNNNNNNNN", 
                        "ONNNNNNNNNNN", 
                        "ONNNNNNNNNNN"
                    }
                },
                {
                    "TestFiles/testFile3.txt",
                    new string[]
                    {
                        "ONNNNNNN", 
                        "NNNNONNN", 
                        "NNNNNNNN"
                    }
                },
                {
                    "TestFiles/testFile4.txt",
                    new string[]
                    {
                        "ONNNNNNN", 
                        "NNNNONNN", 
                        "NNNNONNO", 
                        "NNNNONNN", 
                        "NNNNNNNN"
                    }
                }
            };
    }
}
