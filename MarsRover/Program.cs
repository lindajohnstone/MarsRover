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
            var mapInput = new FileInput();
            var map = new Map(5, 4, new List<Square>()); // TODO: think this shows I need another class!
            var rover = new Rover(Direction.North, 0, 0); // TODO: 
            var controller = new Controller(input, output, mapInput, map, rover);
            controller.Setup();
        }
    }
}
