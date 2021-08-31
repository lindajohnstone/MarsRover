using Xunit;

namespace MarsRover.Tests
{
    public class FileMapInputShouldTestData
    {
        public static TheoryData<string, string[]> FileMapInputTestData =
            new TheoryData<string, string[]>
            {
                {
                    "TestFiles/validFile1.txt",
                    new string[]
                    {
                        "ONNN",
                        "NNNN",
                        "NNNN"
                    }
                },
                {
                    "TestFiles/validFile2.txt",
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
                    "TestFiles/validFile3.txt",
                    new string[]
                    {
                        "ONNNNNNN", 
                        "NNNNONNN", 
                        "NNNNNNNN"
                    }
                },
                {
                    "TestFiles/validFile4.txt",
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
