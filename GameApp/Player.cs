using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    public abstract class Player
    {
        protected string[] hands = { "Rock", "Paper", "Scissors" };

        public virtual string Name { get; set; }

        public abstract string GetSelection();
    }
}
