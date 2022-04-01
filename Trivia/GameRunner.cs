using Trivia.Implementations;
using Trivia.Ports;

namespace Trivia
{
    public class GameRunner
    {
        private readonly IRandomNumberGenerator _rng;
        private readonly IOutput _output;
        private bool _notAWinner;

        public GameRunner(IRandomNumberGenerator rng, IOutput output)
        {
            _rng = rng;
            _output = output;
        }

        public void Play()
        {
            var aGame = new Game(_output);

            aGame.Add("Chet");
            aGame.Add("Pat");
            aGame.Add("Sue");
            
            do
            {
                aGame.Roll(_rng.Next(5) + 1);

                if (_rng.Next(9) == 7)
                {
                    _notAWinner = aGame.WrongAnswer();
                }
                else
                {
                    _notAWinner = aGame.WasCorrectlyAnswered();
                }
            } while (_notAWinner);
        }
    }
}
