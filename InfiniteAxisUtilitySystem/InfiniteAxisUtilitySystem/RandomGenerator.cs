using System;

namespace InfiniteAxisUtilitySystem
{
    public class RandomGenerator : IRandomGenerator
    {
        readonly Random _random;

        public RandomGenerator()
        {
            _random = new Random();
        }

        public RandomGenerator(int seed)
        {
            _random = new Random(seed);
        }

        public double Next() => _random.NextDouble();
    }
}