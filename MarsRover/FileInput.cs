using System.IO;

namespace MarsRover
{
    public class FileInput 
    {
        public string Read(string input)
        {
            return File.ReadAllText(input);
        }

        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
