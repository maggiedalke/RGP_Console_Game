using System;
using System.Collections.Generic;
using System.Text;

namespace maggie_rpg_game
{
    class Equipment
    {
        public string Name { get; set; }
        public int Power { get; set; }

        public Equipment(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }
    }
}
