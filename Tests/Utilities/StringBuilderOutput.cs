using System.Text;
using Trivia.Ports;

namespace Tests.Utilities
{
    internal class StringBuilderOutput : IOutput
    {
        private readonly StringBuilder _builder = new StringBuilder();

        /// <inheritdoc />
        public void WriteLine(string @string)
            => _builder.AppendLine(@string);

        /// <inheritdoc />
        public override string ToString() => _builder.ToString();
    }
}
