using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GameApp.Test
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Game_Returns_Winner_BasedOn_Rules()
        {
            var newGame = new Game(2, 3);
            var rule1 = new Rule { Winner = "Rock", Looser = "Scissors" };
            var rule2 = new Rule { Winner = "Scissors", Looser = "Paper" };
            var rule3 = new Rule { Winner = "Paper", Looser = "Rock" };

            var person = new SimulateComputerPlayer();
            var computer = new TestPlayer();
            var game = new Game(2, 3);
            game.AddRules(new List<Rule> { rule1, rule2, rule3 });

            game.AddPlayers(new List<Player> { person, computer });

            game.PlayGame();

            var winner = game.Winner;
            var thWinner = winner is SimulateComputerPlayer;

            Assert.IsNotNull(winner);
            Assert.IsNotNull(thWinner);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Game_Throws_Exception_When_No_Rules_Set_up()
        {
            var newGame = new Game(2, 3);
            var rule1 = new Rule { Winner = "Rock", Looser = "Scissors" };
            var rule2 = new Rule { Winner = "Scissors", Looser = "Paper" };
            var rule3 = new Rule { Winner = "Paper", Looser = "Rock" };

            var person = new SimulateComputerPlayer();
            var computer = new TestPlayer();
            var game = new Game(2, 3);
            game.AddPlayers(new List<Player> { person, computer });
            game.PlayGame();

        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Game_Throws_Exception_When_No_Players_Set_up()
        {
            var newGame = new Game(2, 3);
            var rule1 = new Rule { Winner = "Rock", Looser = "Scissors" };
            var rule2 = new Rule { Winner = "Scissors", Looser = "Paper" };
            var rule3 = new Rule { Winner = "Paper", Looser = "Rock" };

            var person = new SimulateComputerPlayer();
            var computer = new TestPlayer();
            var game = new Game(2, 3);
            game.PlayGame();

        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Game_Throws_Exception_When_No_Is_Less_Than_Minimum_Players()
        {
            var newGame = new Game(2, 3);
            var rule1 = new Rule { Winner = "Rock", Looser = "Scissors" };
            var rule2 = new Rule { Winner = "Scissors", Looser = "Paper" };
            var rule3 = new Rule { Winner = "Paper", Looser = "Rock" };

            var person = new SimulateComputerPlayer();
            var computer = new TestPlayer();
            var game = new Game(2, 3);
            game.AddPlayers(new List<Player> { person });

            game.PlayGame();

        }
    }
}
