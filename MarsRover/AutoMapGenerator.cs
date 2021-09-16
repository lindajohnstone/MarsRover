using System;
using System.Collections.Generic;
using System.IO;

namespace MarsRover
{
    public class AutoMapGenerator
    {
        private readonly IMapInput _mapInput;
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly FileRegister _fileRegister;
        private readonly IRandomGenerator _random;

        public AutoMapGenerator(IInput input, IOutput output, IMapInput fileMapInput, FileRegister fileRegister, IRandomGenerator random)
        {
            _mapInput = fileMapInput;
            _output = output;
            _input = input;
            _fileRegister = fileRegister;
            _random = random;
        }

        public Map Map { get; private set; }
        /*
            user enters directory name
            check if directory exists (think this is where 1 issue is)
            keep asking for input until directory.exists
            randomly pick a file from the directory
            validate it has valid map data
            if it is a valid map file, parse it
            
        */
        public void Initialise()
        {
            var directory = GetValidDirectory();
            //_output.WriteLine(directory);
            var specifier = "*.txt";
            var filePath = GetValidFilePath(directory);
            var input = _mapInput.Read(filePath);
            var isValidMap = Validator.IsValidMap(input);
            while (!isValidMap)
            {
                filePath = GetValidFilePath(directory);
                input = _mapInput.Read(filePath);
                isValidMap = Validator.IsValidMap(input);
            }
            Map = MapParser.ParseMap(input);
        }

        private string GetValidDirectory()
        {
            var directory = _input.ReadLine();
            var directoryExists = _fileRegister.DirectoryExists(directory);
            //_output.WriteLine("directory Exists");
            while (!directoryExists)
            {
                _output.WriteLine(Messages.InvalidInput);
                _output.WriteLine(Messages.RequestMapInput);
                directory = _input.ReadLine();
                directoryExists = _fileRegister.DirectoryExists(directory);
            }
            return directory;
        }

        private string GetValidFilePath(string directory)
        {
            var files = _fileRegister.GetFiles(directory);
            //_output.WriteLine(String.Join(",", files));
            var filePath = _random.RandomString(files);
            var fileExists = _mapInput.FileExists(filePath);
            while (!fileExists)
            {
                filePath = _random.RandomString(files);
                fileExists = _mapInput.FileExists(filePath);
            }
            return filePath;
        }
    }
}
