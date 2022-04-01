using Trivia.Implementations;
using Trivia.Ports;

namespace Trivia
{
    internal class GameRunner
    {
        private IRandomNumberGenerator _rng = new FrameworkRandomNumberGenerator();
        private bool _notAWinner;

        public void Play()
        {
            var aGame = new Game();

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
