using System;
using System.Diagnostics.CodeAnalysis;

namespace MarsRover
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            var input = new ConsoleInput();
            var output = new ConsoleOutput();
            var mapInput = new FileMapInput();
            var mapGenerator = new MapGenerator(input, output, mapInput);
            var fileRegister = new FileRegister();
            var randomGenerator = new RandomGenerator(new Random());
            var autoMapGenerator = new AutoMapGenerator(input, mapInput, fileRegister, randomGenerator);
            var generator = new Generator(input, output, mapGenerator, autoMapGenerator);
            var controller = new Controller(input, output, generator);
            controller.Run();
        }
    }
}
