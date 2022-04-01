using Trivia;
using Trivia.Implementations;

var rng = new FrameworkRandomNumberGenerator();
var output = new FrameworkConsoleOutput();

new GameRunner(rng, output).Play();