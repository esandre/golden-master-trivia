using System;
using Trivia.Ports;

namespace Trivia.Implementations
{
    public class FrameworkConsoleOutput : IOutput
    {
        /// <inheritdoc />
        public void WriteLine(string @string) => Console.WriteLine(@string);
    }
}
