using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Utilities;
using Trivia;
using Trivia.Implementations;
using Xunit;

namespace Tests
{
    public class ExportGoldenMaster
    {
        private readonly GoldenMasterPersister _persister = new GoldenMasterPersister();

        [Fact (Skip = "Déclencher manuellement au besoin")]
        public async Task Export()
        {
            var goldenMaster = new Dictionary<string, string>();
            const int nombreParties = 10;

            for (var i = 0; i < nombreParties; i++)
            {
                var rng = new SpyRandomNumberGenerator(new FrameworkRandomNumberGenerator());
                var output = new StringBuilderOutput();

                var gameRunner = new GameRunner(rng, output);
                gameRunner.Play();

                var input = rng.Logged;

                goldenMaster.Add(input, output.ToString());
            }

            await _persister.PersistAsync(goldenMaster);
        }

        [Fact]
        public async Task Verify()
        {
            var goldenMaster = await _persister.Read();

            foreach (var (input, expectedOutput) in goldenMaster)
            {
                var rng = new PredefinedValuesRandomNumberGenerator(
                    input.Select(@char => int.Parse(new string(new [] { @char })))
                );

                var output = new StringBuilderOutput();

                var gameRunner = new GameRunner(rng, output);
                gameRunner.Play();

                Assert.Equal(expectedOutput, output.ToString());
            }
        }
    }
}
