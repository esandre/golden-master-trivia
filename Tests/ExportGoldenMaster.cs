using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Tests.Utilities;
using Trivia;
using Trivia.Implementations;
using Xunit;

namespace Tests
{
    public class ExportGoldenMaster
    {
        [Fact]
        public void Export()
        {
            var goldenMaster = new Dictionary<string, string>();
            const int nombreParties = 10;

            for (int i = 0; i < nombreParties; i++)
            {
                var rng = new SpyRandomNumberGenerator(new FrameworkRandomNumberGenerator());
                var output = new StringBuilderOutput();

                var gameRunner = new GameRunner(rng, output);
                gameRunner.Play();

                var input = rng.Logged;

                goldenMaster.Add(input, output.ToString());
            }

            Assert.NotEmpty(goldenMaster);
        }
    }
}
