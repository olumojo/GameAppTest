using System;
using System.Collections.Generic;

namespace GameApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please select the number infront of the selection to select your selection");
            Console.WriteLine("Rock :  0");
            Console.WriteLine("Paper :  1");
            Console.WriteLine("Scissors :  2");
            Console.WriteLine(" ");

            var rule1 = new Rule { Winner = "Rock", Looser = "Scissors" };
            var rule2 = new Rule { Winner = "Scissors", Looser = "Paper" };
            var rule3 = new Rule { Winner = "Paper", Looser = "Rock" };

            var person = new HumanPlayer();
            var computer = new RandomComputerPlayer();
            try
            {
                var game = new Game(2, 3);
                game.AddRules(new List<Rule> { rule1, rule2, rule3 });

                game.AddPlayers(new List<Player> { person, computer });

                game.PlayGame();

                var winner = game.Winner;
                if (winner == null)
                {
                    Console.WriteLine("It was a draw, try again next time");
                }
                else if (winner is HumanPlayer)
                    Console.WriteLine("You have won this time around, Congratulations");
                else
                {
                    Console.WriteLine("You have been beaten, the Computer has won");
                }
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                //log
                Console.WriteLine(ex.Message);
            }
          
        }
    }
}
 