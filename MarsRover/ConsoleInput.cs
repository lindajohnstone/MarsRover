using System;

namespace MarsRover
{
    public class ConsoleInput : IInput
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}