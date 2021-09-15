using System;

namespace MarsRover
{
    public class RandomGenerator : IRandomGenerator
    {
        public string RandomString(string[] values, int max)
        {
            Random random = new Random();
            var index = random.Next(0, values.Length - 1);
            return values[index];
        }
    }
}
