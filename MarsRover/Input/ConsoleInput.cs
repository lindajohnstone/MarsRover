using System;
using System.Diagnostics.CodeAnalysis;

namespace MarsRover
{
    public class ConsoleInput : IInput
    {
        [ExcludeFromCodeCoverage]
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}