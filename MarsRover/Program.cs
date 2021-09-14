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
            var generator = new Generator(input, output, mapInput);
            var controller = new Controller(input, output, generator);
            controller.Run();
        }
    }
}
