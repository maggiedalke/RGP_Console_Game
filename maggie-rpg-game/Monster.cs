using System;
using System.Collections.Generic;
using System.Text;

namespace maggie_rpg_game
{
    class Monster 
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHealth { get; set; }
        public int CurrentHealth { get; set; }
        public LivingStatus Status { get; set; }

        public Monster()
        {
        }

        public Monster(string name, int originalHealth, int strength, int defense, string description)
        {
            this.Name = name;
            this.OriginalHealth = originalHealth;
            this.CurrentHealth = OriginalHealth;
            this.Strength = strength;
            this.Defense = defense;
            this.Description = description;                     
        }
    }
}
