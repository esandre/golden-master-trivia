using System;
using System.Linq;
using Tests.Utilities;
using Trivia;
using Xunit;

namespace Tests
{
    public class Defects
    {
        /**
         * Actions effectuées :
         * - Le maître du jeu n'a ajouté qu'un seul joueur.
         *
         * Comportement attendu :
         * - La partie ne doit pas démarrer et une erreur "Vous devez avoir au moins 2 joueurs."
         * doit être renvoyée dans la console.
         *
         * Comportement obtenu :
         * - La partie démarre normalement.
         *
         * Cause :
         * - Play a démarré sans contrôler le nombre de joueurs.
         *
         * Solution choisie :
         * - Ajouter une clause de garde à l'entrée de Play.
         */
        [Fact(DisplayName = "A Game could have less than two players - make sure it always has at least two")]
        public void UnJoueurs()
        {
            var sortie = new StringBuilderOutput();
            var gameRunner = new GameRunner(new StubRandomNumberGenerator(), sortie);
            gameRunner.Play("Joueur");

            var sortieObtenue = sortie.ToString();
            Assert.DoesNotContain("Joueur is the current player", sortieObtenue);

            var dernièreLigne = sortieObtenue.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Last();

            Assert.Equal("Vous devez avoir au moins 2 joueurs.", dernièreLigne);
        }

        /**
         * Actions effectuées :
         * - Le maître du jeu n'a pas ajouté de joueurs.
         *
         * Comportement attendu :
         * - La partie ne doit pas démarrer et une erreur doit être renvoyée
         *
         * Comportement obtenu :
         * - La partie ne démarre pas, mais plante sans renvoyer d'erreur claire.
         *
         * Cause :
         * - 
         *
         * Solution choisie :
         * -
         */
        //[Fact(DisplayName = "A Game could have less than two players - make sure it always has at least two")]
        //public void ZeroJoueurs()
        //{
        //    var sortie = new StringBuilderOutput();
        //    var gameRunner = new GameRunner(new StubRandomNumberGenerator(), sortie);

        //    void Act() => gameRunner.Play(Enumerable.Repeat("Joueur", nombreJoueursInvalide).ToArray());

        //    Act();
        //}
    }
}
