using Xunit;

namespace MarsRover.Tests
{
    public class FileInputShouldTestData
    {
        public static TheoryData<string, string[]> FileInputTestData =
            new TheoryData<string, string[]>
            {
                {
                    "TestFiles/valid-file-1.txt",
                    new string[]
                    {
                        "ONNN",
                        "NNNN",
                        "NNNN"
                    }
                },
                {
                    "TestFiles/valid-file-2.txt",
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
                    "TestFiles/valid-file-3.txt",
                    new string[]
                    {
                        "ONNNNNNN", 
                        "NNNNONNN", 
                        "NNNNNNNN"
                    }
                },
                {
                    "TestFiles/valid-file-4.txt",
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
