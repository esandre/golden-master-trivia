using System.Text;
using Trivia.Ports;

namespace Tests.Utilities
{
    internal class SpyRandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly StringBuilder _log;
        private readonly IRandomNumberGenerator _inner;

        public SpyRandomNumberGenerator(IRandomNumberGenerator inner)
        {
            _log = new StringBuilder();
            _inner = inner;
        }

        /// <inheritdoc />
        public int Next(int maxValue)
        {
            var number = _inner.Next(maxValue);
            _log.Append(number);
            return number;
        }

        public string Logged => _log.ToString();
    }
}
