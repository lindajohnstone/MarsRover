using System.IO;

namespace MarsRover
{
    public class FileInput : IInput
    {
        public string Read(string input)
        {
            return File.ReadAllText(input);
        }
    }
}