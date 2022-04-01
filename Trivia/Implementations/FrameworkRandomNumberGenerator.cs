using System;
using Trivia.Ports;

namespace Trivia.Implementations
{
    public class FrameworkRandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly Random _random = new Random();

        /// <inheritdoc />
        public int Next(int maxValue) => _random.Next(maxValue);
    }
}
