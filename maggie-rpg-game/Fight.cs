using System;
using System.Collections.Generic;
using System.Text;

namespace maggie_rpg_game
{
    public enum LivingStatus
    {
        alive,
        dead,
    }

    class Fight
    {
        public List<Monster> Monsters { get; set; }
        public Monster CurrentMonster { get; set; }
        public Hero hero { get; set; }
        public List<Monster> MonsterList = new List<Monster>()
            {
            new Monster("Cave Bat", 20, 2, 2, "with their wings, these are the only mamal capable of ture sustained flight."),
            new Monster("Skeleton", 26, 2, 5, "Arisen by dark magic, the skeleton are a mindless and merciless creature \nthat continue to attack until it has killed or has been killed."),
            new Monster("Shreiker", 28, 6, 8, "This Humanoid Mushroom emits a piercing Screech to drive off creatures \nthat disturb it."),
            new Monster("Bold Jumper", 25, 6, 6, "This spider does not just bite, it jumps! With it's black body \nit can easily camouflage into the shadows."),
            new Monster("Blood Spirit", 20, 7, 10, "This spirit tries to possess anyone who seeks to learn blood magic."),
            new Monster("Bronze Golem", 70, 20, 2, "Magically created by wizards or clerics, \nthis mindless beast is built for fighting."),
            new Monster("Desert Runner", 25, 6, 9, "From a tribe that survived in the desert for centuries... \nthe Desert Runner is easily confused and hostile when confronted."),
            new Monster("Kobold", 36, 15, 9, "Reptilian Humanoid - With their Scaled bodies and crocodile like jaw, \nthis Kobold is looking to conqure as much land as possible."),
            new Monster("Baboon", 30, 23, 12, "The Baboon has no allegiance to anyone and will attack anything that moves."),
            new Monster("Ent", 60, 17, 16, "Full Name: Treant,  tree destined to become a treant meditates \nthrough a long cycle of seasons, living normally for decades or centuries before realizing its potential"),
            new Monster("Blink Dog", 35, 26, 18, "By magically teleporting, this dog can sneak up and attack any target."),
            new Monster("Couatl", 42, 30, 15, "A serpent that has a spellcatsing ability, can transform into any humanoid or beast."),
            new Monster("Dark Knight", 50, 20, 30, "Without a master, this knight forges his own destiny through life. \nThey tend to rely on the power of darkness for their gain."),
            new Monster("Dire Wolf", 80, 30, 40, "Watch out for this wolf's bite!"),
            new Monster("Earth Elemental", 180, 50, 60, "The elemental can Burrow through nonmagical, unworked earth and stone. \nWhile doing so, the elemental doesn't disturb the material it moves through."),
            new Monster("Fire Dragon", 220, 100, 153, "Evil creatures, interested only in their own well-being, \nthey are supremely confident of their own abilities and prone to making snap decisions without any forethought."),
            new Monster("Adult Copper Dragon", 350, 180, 200, "Using it's Lightining breath, this amphibous dragon demolishes everything in it's path.")
            };

        /* ********** TESTING **************
           Here is a smaller list of monsters, this could help with testing for errors. 

        //public List<Monster> MonsterList = new List<Monster>()
        //    {
        //    new Monster("Cave Bat", 20, 2, 2, "with their wings, these are the only mamal capable of ture sustained flight."),       
        //    new Monster("Baboon", 30, 23, 12, "The Baboon has no allegiance to anyone and will attack anything that moves."),         
        //    new Monster("Dark Knight", 50, 20, 30, "Without a master, this knight forges his own destiny through life. \nThey tend to rely on the power of darkness for their gain."),       
        //    new Monster("Adult Copper Dragon", 350, 180, 200, "Using it's Lightining breath, this amphibous dragon demolishes everything in it's path.")
        //    };
        */

        public Fight(Hero hero)
        {
            this.hero = hero;
        }

        public void StartFight()
        {
            Console.WriteLine("Do you want to fight the strongest monster? Y/N");
            if (checkSpawnStrongestMonster())
                CurrentMonster = SpawnStrongestMonster(MonsterList);
             else
                CurrentMonster = SpawnRandomMonster(MonsterList);
            Console.Clear();

            PrintMonster(CurrentMonster);

            Console.WriteLine("\nTo start the fight, press enter.");
            Console.ReadLine();

            Console.Clear();
            hero.Status = LivingStatus.alive;
            CurrentMonster.Status = LivingStatus.alive;
            bool BothAlive = true;
            int RoundNum = 1;

            while (BothAlive)
            {
                PrintCurrentGame();
                Console.WriteLine($"ROUND {RoundNum}");
                Console.WriteLine("-----------------------");
                HeroTurn();
                if (CurrentMonster.Status == LivingStatus.dead)
                {
                    Console.ReadLine();
                    break;
                }

                MonsterTurn();
                if (hero.Status == LivingStatus.dead)
                {
                    Console.ReadLine();
                    BothAlive = false;
                }
                Console.Clear();
                RoundNum++;
            }
            Console.Clear();
        }
        
        public void PrintCurrentGame()
        {
            Console.WriteLine("LET'S BATTLE!");
            Console.WriteLine($"{hero.Name}");
            Console.WriteLine($"Health:{hero.CurrentHealth}/{hero.OriginalHealth} Attack:{hero.Strength + hero.EquippedWeapon.Power} Defense:{hero.Defense + hero.EquippedArmor.Power}");
            Console.WriteLine($"\n{CurrentMonster.Name}");
            Console.WriteLine($"Health:{CurrentMonster.CurrentHealth}/{CurrentMonster.OriginalHealth} Attack:{CurrentMonster.Strength} Defense:{CurrentMonster.Defense}\n");
        }
        
        public Monster SpawnRandomMonster(List<Monster> monsters)
        {
            Random random = new Random();
            int monsterIndex = random.Next(monsters.Count);
            return monsters[monsterIndex];
        }
        
        public Monster SpawnStrongestMonster(List<Monster> monsters)
        {
            Monster strongestMonster = new Monster();
            foreach(var monster in monsters)
            {
                if(monster.Strength > strongestMonster.Strength)
                {
                    strongestMonster = monster;
                }                
            }
            return strongestMonster;
        }
        
        public bool checkSpawnStrongestMonster()
        {
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                return true;
            }
            return false;
        }

        public void PrintMonster(Monster monster)
        {
            Console.WriteLine($"You are currently fighting: {monster.Name}");
            Console.WriteLine($"Health: {monster.CurrentHealth} / {monster.OriginalHealth}");
            Console.WriteLine($"Strength: {monster.Strength}");
            Console.WriteLine($"Defense: {monster.Defense}");
            Console.WriteLine($"More Info: \n{monster.Description}");

        }

        public void HeroTurn()

        {
            if (checkForTie())
                return;

            Console.WriteLine($"\nYour Turn");
            Console.ReadLine();

            if (hero.CoinBag >= 5 && (hero.CurrentHealth < hero.OriginalHealth))
            {
                if (canBuyPotion())
                {
                    GetPotion();
                    return;
                }
            }


            int damageDealt = DealDamageToMonster();
            CurrentMonster.CurrentHealth = CurrentMonster.CurrentHealth - damageDealt;

            if (!CheckForWin())
                Console.WriteLine($"{damageDealt} damage dealt to the {CurrentMonster.Name}");
            else
                printHeroWin();
        }

        public void MonsterTurn()
        {
            Console.WriteLine($"\n{CurrentMonster.Name}'s Turn");
            Console.ReadLine();
            int damageDelt = DealDamageToHero();
            hero.CurrentHealth = hero.CurrentHealth - damageDelt;

            if (!CheckForLose())
            {
                Console.WriteLine($"You took {damageDelt} damage.");
                Console.ReadLine();
            }
            else
                printHeroLose();
        }

        public int DealDamageToMonster()
        {
            int TotalDamage = (hero.Strength + hero.EquippedWeapon.Power) - CurrentMonster.Defense;

            if (TotalDamage <= 0)
            {
                Console.WriteLine($"Oh no! You aren't strong enough to beat the {CurrentMonster.Name}!");
                hero.CurrentHealth = 0;
                TotalDamage = 0;
            }
            return Math.Abs(TotalDamage);
        }

        public int DealDamageToHero()
        {
            int TotalDamage = CurrentMonster.Strength - (hero.Defense + hero.EquippedArmor.Power);

            if (TotalDamage <= 0)
            {
                Console.WriteLine($"{CurrentMonster.Name} can not penetrate your defense.");
                CurrentMonster.CurrentHealth = 0;
                TotalDamage = 0;
            }
            return Math.Abs(TotalDamage);
        }

        public bool canBuyPotion()
        {
            Console.WriteLine("You can either attack or buy a potion in this round.");
            Console.WriteLine("Would you like to buy a healing potion for 5 coins? " +
                "\nY to buy a potion" +
                "\nEnter to return to attack\n");

            if (Console.ReadKey().Key == ConsoleKey.Y)
                return true;

            return false;
        }

        public void GetPotion()
        {
            Console.WriteLine("\nYou are buying a healing potion for 5 coins");
            hero.CoinBag -= 5;
            Random random = new Random();
            int revivedHP = random.Next(8, 13);
            hero.CurrentHealth += revivedHP;
            Console.WriteLine($"You healed {revivedHP} Health\n");
            Console.WriteLine($"{hero.CurrentHealth} / {hero.OriginalHealth}");
        }

        public bool CheckForWin()
        {
            bool win = false;
            if (CurrentMonster.CurrentHealth <= 0)
            {
                CurrentMonster.Status = LivingStatus.dead;
                hero.Strength += 2;
                hero.Defense += 2;
                hero.OriginalHealth += 5;
                hero.TotalGames++;
                hero.GamesWon++;
                win = true;
            }
            return win;
        }

        public bool CheckForLose()

        {
            bool lose = false;
            if (hero.CurrentHealth <= 0)
            {
                hero.Status = LivingStatus.dead;
                hero.TotalGames++;
                hero.GamesLost++;
                lose = true;
            }
            return lose;
        }

        public int GetCoins(int coins)
        {
            Random random = new Random();
            int getMon = random.Next(1, 8);
            return getMon;
        }

        public void loseCoins()
        {
            if (hero.CoinBag > 0)
            {
                int lostCoins = GetCoins(hero.CoinBag);
                int coinNumTrack = hero.CoinBag - lostCoins;                


                if (coinNumTrack < 1)
                {
                    hero.CoinBag = 0;
                    Console.WriteLine($"Oh no! You dropped all your coins running back to the village. " +
                        $"\nAt least you made it back ok!");

                }
                else
                {
                    hero.CoinBag -= lostCoins;
                    string handleCoin = lostCoins == 1 ? "coin" : "coins";
                    Console.WriteLine($"Oh no! You dropped {lostCoins} {handleCoin} while running back to the village. " +
                        $"\nAt least you made it back ok!");
                }


            }
        }

        public void printHeroWin()
        {
            int foundCoins = GetCoins(hero.CoinBag);
            hero.CoinBag += foundCoins;

            string handleCoin = foundCoins == 1 ? "coin" : "coins";

            Console.Clear();
            Console.WriteLine($"You killed the {CurrentMonster.Name}!");
            Console.WriteLine("(Did you have to kill it... do you even have a heart?)\n");

            Console.WriteLine($"Oooohhhh!! You found {foundCoins} {handleCoin} on the ground! ....(Not that you deserve it)");
            Console.WriteLine($"Be sure to put that in your coin bag for safe keeping!");
            Console.WriteLine();

            Console.WriteLine($"Let's Check out your new Stats!\n");
            hero.ShowStats();
        }

        public void printHeroLose()
        {

            Console.Clear();
            Console.WriteLine($"You were defeated by the {CurrentMonster.Name}...\n");

            loseCoins();

            Console.WriteLine("Dont give up! Everyone learns from failing... (well, most people...)\n");

            Console.WriteLine("Maybe changing your equipment would help? **hint, hint** " +
                "\nTake a look at your inventory for stronger weapons and armor!\n");
        }

        public bool checkForTie()
        {
            bool tie = false;
            if ((hero.Defense + hero.EquippedArmor.Power) == CurrentMonster.Strength)
            {
                Console.WriteLine($"You and the {CurrentMonster.Name} are evenly matched.");
                Console.WriteLine("No winner or loser.");
                Console.WriteLine("Perhaps you will meet in the woods again, one day...");
                hero.GamestTie += 1;
                hero.Status = LivingStatus.dead;
                CurrentMonster.Status = LivingStatus.dead;
                tie = true;
            }
            return tie;
        }

    }
}
