using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public class HumanPlayer : Player
    {
        public override string GetSelection()
        {
            Console.Write("Player Hand : ");
            string playerHand = Console.ReadLine();
            string selectedHand = base.hands[int.Parse(playerHand)];
            return selectedHand;
        }
    }
}
