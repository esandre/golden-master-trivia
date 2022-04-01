using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Utilities
{
    internal class GoldenMasterPersister
    {
        private const string Path = "C:\\Users\\kryza\\Documents\\Sources\\YNOV\\trivia-master\\Trivia\\GoldenMaster.txt";
        private const string EndOfBlock = "---END OF BLOCK---";

        public async Task PersistAsync(IReadOnlyDictionary<string, string> goldenMaster)
        {
            var file = File.OpenWrite(Path);
            foreach (var (input, output) in goldenMaster)
            {
                var block = input + Environment.NewLine
                                  + output;

                if (!block.EndsWith(Environment.NewLine))
                    block += Environment.NewLine;

                block += EndOfBlock + Environment.NewLine;

                await file.WriteAsync(Encoding.UTF8.GetBytes(block));
            }
        }

        public async Task<IReadOnlyDictionary<string, string>> Read()
        {
            var dictionary = new Dictionary<string, string>();
            var inputs = string.Empty;
            var outputs = new StringBuilder();

            await foreach(var line in ReadLines())
            {
                if(line == EndOfBlock)
                {
                    dictionary.Add(inputs, outputs.ToString());
                    inputs = string.Empty;
                    outputs.Clear();
                    continue;
                }

                if (string.IsNullOrEmpty(inputs)) inputs = line;
                else outputs.AppendLine(line);
            }

            return dictionary;
        }

        private async IAsyncEnumerable<string> ReadLines()
        {
            var file = File.OpenRead(Path);
            using var reader = new StreamReader(file, Encoding.UTF8);

            var line = await reader.ReadLineAsync();
            while (line != null)
            {
                yield return line;
                line = await reader.ReadLineAsync();
            }
        }
    }
}
