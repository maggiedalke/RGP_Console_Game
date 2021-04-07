using System;
using System.Collections.Generic;
using System.Text;

namespace maggie_rpg_game
{
    class Game
    {
        public Hero Hero { get; set; }
        public Monster Monster { get; set; }
        public Fight Fight { get; set; }

        public Game()
        {
        }

        public Game(Hero hero)
        {
            this.Hero = hero;
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to Tamaki Island! \n\nRecently there have been a lot of monsters around... " +
                "\nthey are terrorizing the town!" +
                "\nwe really need a hero's help...\n");
            Console.WriteLine("Oh A Hero! \nWhat is your name?");
            string CheckHeroName = Console.ReadLine();            
            string heroName = validateName(CheckHeroName);
            Hero hero = new Hero(heroName);           

            bool quit = false;

            while (!quit)
            {
                hero.CurrentHealth = hero.OriginalHealth;
                Console.WriteLine("MAIN MENU");                
                Console.WriteLine($"\nPlease choose an action and press enter: " +
                    $"\n[1] Check {hero.Name}'s Stats" +
                    $"\n[2] Check Inventory" +
                    $"\n[3] Start the Fight!" +
                    $"\n[4] Leave the Island");

                int choice = validateNum(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine($"{hero.Name}'s Current Stats:\n");
                        hero.ShowStats();
                        Console.WriteLine("\nReturn to the Main Menu");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        hero.ShowInventory();
                        Console.WriteLine("\nWould you like to change your equipment? " +
                            "\nY to change. " +
                            "\nEnter to return to the main menu");

                        bool change = checkIfChangeEquipment();                        
                        if (change)
                        {
                            Console.Clear();
                            hero.changeWeapon(hero.WeaponsBag);
                            hero.changeArmor(hero.ArmorBag);
                            Console.Clear();
                            Console.WriteLine($"Your new equipment:");
                            Console.WriteLine($"Weapon: {hero.EquippedWeapon.Name} Power:{hero.EquippedWeapon.Power}");
                            Console.WriteLine($"Armor: {hero.EquippedArmor.Name} Power:{hero.EquippedArmor.Power}");
                            Console.WriteLine("\nReturn to the Main Menu");
                            Console.ReadLine();
                        }
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Fight newFight = new Fight(hero);
                        newFight.StartFight();
                        break;
                    case 4:
                        quit = quitGame();
                        break;
                }
            }
        }

        public string validateName(string name)
        {
            bool checkValidName = false;
            string validName = null;

            while (!checkValidName)
            {
                if (string.IsNullOrEmpty(name))
                {

                    Console.WriteLine("You don't have a name...? \nEvery Hero needs a name!" +
                        "\n\nWhy don't you make one up!? (Let's keep it between 3-10 characters)");
                    name = Console.ReadLine();
                }
                else if (name.Length < 3 || name.Length > 10)
                {
                    Console.WriteLine("\nWow, That's a great name... " +
                        "\nLet's just keep it between 3-10 characters " +
                        "\nPlease enter your Hero name!");
                    name = Console.ReadLine();
                }
                else
                {
                    validName = name.ToLower();
                    checkValidName = true;
                }
            }

            Console.Clear();
            return char.ToUpper(validName[0]) + validName.Substring(1);
        }

        public int validateNum(string input)
        {
            int validNum;

            while (!int.TryParse(input, out validNum))
            {
                Console.WriteLine("You did not enter a valid number, please enter a choice between 1 and 4");
                input = Console.ReadLine();
            }

            bool isValidRange = false;

            while (!isValidRange)
            {
                if (validNum == 1 || validNum == 2 || validNum == 3 || validNum == 4)
                {
                    return validNum;
                }
                Console.WriteLine("Please enter a number between 1 and 4");
                validNum = validateNum(Console.ReadLine());
                isValidRange = false;
            }
            return validNum;
        }

        public bool checkIfChangeEquipment()
        {
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                return true;
            }
            return false;
        }

        public bool quitGame()
        {
            Console.Clear();
            Console.WriteLine("YOU WILL LOSE ALL YOUR PROGRESS IF YOU LEAVE!" +
                "\nPress Q to Leave the island.");
            if (Console.ReadKey().Key == ConsoleKey.Q)
            {
                Console.Clear();
                return true;
            }
            else
            {
                Console.Clear();
                return false;
            }
        }
    }

}

