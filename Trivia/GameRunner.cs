using System.Collections.Generic;
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

        public void Play(params string[] joueurs)
        {
            var aGame = new Game(_output);
            foreach (var joueur in joueurs)
                aGame.Add(joueur);

            if(joueurs.Length == 1)
            {
                _output.WriteLine("Vous devez avoir au moins 2 joueurs.");
                return;
            }

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
