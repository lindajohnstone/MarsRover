using System.IO;

namespace MarsRover
{
    public class FileInput : IInput
    {
        public string Read(string input)
        {
            return File.ReadAllText(input);
        }

        public string FileExists(string filePath)
        {
            if (File.Exists(filePath)) return filePath;
            return "File does not exist.";
        }
    }
}