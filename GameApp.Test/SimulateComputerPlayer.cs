using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp.Test
{
    public class SimulateComputerPlayer : Player
    {
        int count = 2;
        public SimulateComputerPlayer()
        {

        }

        public override string GetSelection()
        {
            string testHand = base.hands[count];
            count = count - 1;
            return testHand;
        }
    }
}
