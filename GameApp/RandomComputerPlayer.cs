using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public class RandomComputerPlayer : Player
    {
        public override string GetSelection()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 3);
            string computerHand = base.hands[randomNumber];
            return computerHand;
        }
    }
}
