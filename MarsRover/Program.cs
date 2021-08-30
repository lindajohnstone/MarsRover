using System;
using System.Collections.Generic;
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
            var controller = new Controller(input, output, mapInput);
            controller.Setup();
        }
    }
}
