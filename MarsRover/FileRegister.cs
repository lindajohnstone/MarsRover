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
    }
}
