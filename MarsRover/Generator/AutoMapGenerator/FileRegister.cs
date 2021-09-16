using System;
using System.IO;

namespace MarsRover
{
    public class FileRegister
    {
        public string[] GetFiles(string directory, string specifier)
        {
            return Directory.GetFiles(directory, specifier);
        }

        public bool DirectoryExists(string directory)
        {
            return Directory.Exists(directory);
        }

        public string[] GetFiles(string directory)
        {
            return Directory.GetFiles(directory);
        }
    }
}
