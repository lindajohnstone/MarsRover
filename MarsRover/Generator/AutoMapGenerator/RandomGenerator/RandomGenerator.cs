using System;

namespace MarsRover
{
    public class RandomGenerator : IRandomGenerator
    {
        Random _random;

        public RandomGenerator(Random random)
        {
            _random = random;
        }

        public string RandomString(string[] values)
        {
            var index = _random.Next(0, values.Length - 1);
            return values[index];
        }
    }
}
