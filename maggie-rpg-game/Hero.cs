using System;
using System.Collections.Generic;
using System.Text;

namespace maggie_rpg_game
{
    class Hero
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int TotalGames { get; set; }
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }
        public int GamestTie { get; set; }
        public int CoinBag = 200;
        public int Defense { get; set; }
        public int OriginalHealth { get; set; }
        public int CurrentHealth { get; set; }
        public LivingStatus Status { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public List<Weapon> WeaponsBag { get; set; }
        public List<Armor> ArmorBag { get; set; }

        public Hero(string name)
        {
            this.Name = name;
            Random random = new Random();
            this.OriginalHealth = Math.Abs(random.Next(30, 45));
            this.CurrentHealth = OriginalHealth;
            this.Defense = Math.Abs(random.Next(1, 3));
            this.Strength = Math.Abs(random.Next(2, 5));
            this.WeaponsBag = new List<Weapon>()
            {
                new Weapon("Dagger", 5),
                new Weapon("Sickle", 8),
                new Weapon("Long Sword", 9),
                new Weapon("Crossbow", 10)
            };
            this.ArmorBag = new List<Armor>()
            {
                new Armor("Leather", 5),
                new Armor("Scale Mail", 8),
                new Armor("Half Plate", 10),
                new Armor("Chain Mail", 12),
            };
            this.EquippedWeapon = EquipWeapon(this.WeaponsBag);
            this.EquippedArmor = EquipArmor(this.ArmorBag);
        }


        public Weapon EquipWeapon(List<Weapon> weaponsList)
        {
            Random random = new Random();
            int weapon = random.Next(weaponsList.Count);
            Weapon spawnedWeapon = weaponsList[weapon];
            WeaponsBag.Remove(weaponsList[weapon]);
            return spawnedWeapon;
        }

        public Armor EquipArmor(List<Armor> armorList)
        {
            Random random = new Random();
            int armor = random.Next(armorList.Count);
            Armor spawnedArmor = armorList[armor];
            ArmorBag.Remove(armorList[armor]);
            return spawnedArmor;
        }

        public void changeWeapon(List<Weapon> weaponList)
        {
            Console.WriteLine("Weapons Bag:\n");
            Console.WriteLine($"Currently Equipped: {this.EquippedWeapon.Name} Power:{this.EquippedWeapon.Power}\nIn Bag:");            
            int index = 0;
            foreach (var weapon in weaponList)
            {
                Console.WriteLine("[" + index + "]" + "Type: " + weapon.Name + " - Power: " + weapon.Power);
                index++;
            }
            Console.WriteLine("\nChoose item to equip by the number inside []");

            bool validChoice = false;
            while (!validChoice)
            {
                string weaponChoice = Console.ReadLine();
                validChoice = validateWeaponChoice(weaponChoice, weaponList);
                if (validChoice)
                {
                    Weapon new_weapon = weaponList[int.Parse(weaponChoice)];
                    weaponList.Remove(new_weapon);
                    weaponList.Add(this.EquippedWeapon);
                    this.EquippedWeapon = new_weapon;
                }
            }
            Console.WriteLine($"You have Equipped: {this.EquippedWeapon.Name} Power:{this.EquippedWeapon.Power}");
        }

        public void changeArmor(List<Armor> armorList)
        {
            Console.WriteLine("\nArmor Bag:");
            Console.WriteLine($"Currently Equipped: {this.EquippedArmor.Name} Power:{this.EquippedArmor.Power}\nIn Bag:");            
            int index = 0;
            foreach (var armor in armorList)
            {
                Console.WriteLine("[" + index + "]" + "Type: " + armor.Name + " - Power: " + armor.Power);
                index++;
            }
            Console.WriteLine("\nChoose item to equip by the number inside []");

            bool validChoice = false;
            while (!validChoice)
            {
                string armorChoice = Console.ReadLine();
                validChoice = validateArmorChoice(armorChoice, armorList);
                if (validChoice)
                {
                    Armor new_armor = armorList[int.Parse(armorChoice)];
                    armorList.Remove(new_armor);
                    armorList.Add(this.EquippedArmor);
                    this.EquippedArmor = new_armor;
                }
                Console.WriteLine($"You have Equipped: {this.EquippedArmor.Name} Power:{this.EquippedArmor.Power}");
            }
        }

        public bool validateWeaponChoice(string input, List<Weapon> weaponsList)
        {
            try
            {
                int inputValue = int.Parse(input);
                if (inputValue >= 0 && inputValue < weaponsList.Count)
                    return true;
                else
                    return false;
            }
            catch
            {
                Console.WriteLine("Please enter a valid number.");
                Console.WriteLine($"Between 0 - {weaponsList.Count - 1}");
                return false;
            }
        }

        public bool validateArmorChoice(string input, List<Armor> armorList)
        {
            try
            {
                int inputValue = int.Parse(input);

                if (inputValue >= 0 && inputValue < armorList.Count)
                    return true;
                else
                    return false;

            }
            catch
            {
                Console.WriteLine("Please enter a valid number.");
                Console.WriteLine($"Between 0 - {armorList.Count - 1}");
                return false;
            }
        }

        public void ShowStats()
        {            
            Console.WriteLine($"Games Played: {this.TotalGames} ");
            Console.WriteLine($"Games Won: {this.GamesWon} ");
            Console.WriteLine($"Games Lost: {this.GamesLost} ");
            Console.WriteLine($"Games Tied: {this.GamestTie} ");
            Console.WriteLine($"Health: {this.CurrentHealth = this.OriginalHealth} / {this.OriginalHealth}");
            Console.WriteLine($"Strength: {this.Strength}");
            Console.WriteLine($"Defense: {this.Defense}");
            Console.WriteLine($"Weapon: {this.EquippedWeapon.Name} Power: {this.EquippedWeapon.Power}");
            Console.WriteLine($"Armor: {this.EquippedArmor.Name} Power: {this.EquippedArmor.Power}");
            Console.WriteLine($"Total Attack: {this.Strength + this.EquippedWeapon.Power}");
            Console.WriteLine($"Total Defense: {this.Defense + this.EquippedArmor.Power}");
            Console.WriteLine($"CoinBag: ${this.CoinBag}");
        }

        public void ShowInventory()
        {

            Console.WriteLine($"Currently Eqiupped:" +
                $"\nWEAPON: {this.EquippedWeapon.Name} Power:{this.EquippedWeapon.Power}" +
                $"\nARMOR: {this.EquippedArmor.Name} Power:{this.EquippedArmor.Power}\n");

            Console.WriteLine("Current Inventory\n");
            Console.WriteLine("Weapons:");
            foreach (var weapon in WeaponsBag)
            {
                Console.WriteLine("Type: " + weapon.Name + " - Power: " + weapon.Power);
            }

            Console.WriteLine("\nArmor:");
            foreach (var armorPiece in ArmorBag)
            {
                Console.WriteLine("Type: " + armorPiece.Name + " - Power: " + armorPiece.Power);
            }
        }


    }
}
