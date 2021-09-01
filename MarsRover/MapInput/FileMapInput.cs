using System.IO;

namespace MarsRover
{
   public class FileMapInput : IMapInput
    {
        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public string Read(string input)
        {
            return File.ReadAllText(input);
        }
    }
}
