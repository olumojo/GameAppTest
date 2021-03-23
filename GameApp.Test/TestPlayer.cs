using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp.Test
{
    public class TestPlayer : Player
    {
        int count = 0;
        public TestPlayer()
        {
            
        }

        public override string GetSelection()
        {
            string testHand = base.hands[count];
            count = count + 1;          
            return testHand;
        }
    }
}
