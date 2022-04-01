using Trivia.Ports;

namespace Tests.Utilities
{
    internal class StubRandomNumberGenerator : IRandomNumberGenerator
    {
        /// <inheritdoc />
        public int Next(int maxValue) => default;
    }
}
