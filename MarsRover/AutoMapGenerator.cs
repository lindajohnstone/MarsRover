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
        private readonly IRandomGenerator _randomGenerator;

        public AutoMapGenerator(IInput input, IMapInput fileMapInput, FileRegister fileRegister, IRandomGenerator randomGenerator)
        {
            _mapInput = fileMapInput;
            _input = input;
            _output = new ConsoleOutput();
            _fileRegister = fileRegister;
            _randomGenerator = randomGenerator;
        }

        public Map Initialise()
        {
            _output.WriteLine(Messages.RequestDirectoryInput);
            var directory = GetValidDirectory();
            var specifier = "*.txt";
            var filePath = GetValidFilePath(directory, specifier);
            var input = _mapInput.Read(filePath);
            var isValidMap = Validator.IsValidMap(input);
            while (!isValidMap)
            {
                filePath = GetValidFilePath(directory, specifier);
                input = _mapInput.Read(filePath);
                isValidMap = Validator.IsValidMap(input);
            }
            return MapParser.ParseMap(input);
        }

        private string GetValidDirectory()
        {
            var directory = _input.ReadLine();
            var directoryExists = _fileRegister.DirectoryExists(directory);
            while (!directoryExists)
            {
                _output.WriteLine(Messages.InvalidInput);
                _output.WriteLine(Messages.RequestMapInput);
                directory = _input.ReadLine();
                directoryExists = _fileRegister.DirectoryExists(directory);
            }
            return directory;
        }

        private string GetValidFilePath(string directory, string specifier)
        {
            var files = _fileRegister.GetFiles(directory);
            var filePath = _randomGenerator.RandomString(files);
            var fileExists = _mapInput.FileExists(filePath);
            while (!fileExists)
            {
                filePath = _randomGenerator.RandomString(files);
                fileExists = _mapInput.FileExists(filePath);
            }
            return filePath;
        }
    }
}
