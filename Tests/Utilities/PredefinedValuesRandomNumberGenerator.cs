using System;
using System.Collections.Generic;
using Trivia.Ports;

namespace Tests.Utilities
{
    internal class PredefinedValuesRandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly IEnumerator<int> _values;

        public PredefinedValuesRandomNumberGenerator(IEnumerable<int> values)
        {
            _values = values.GetEnumerator();
        }

        /// <inheritdoc />
        public int Next(int maxValue)
        {
            if (_values.MoveNext()) return _values.Current;
            else throw new InvalidOperationException();
        }
    }
}
