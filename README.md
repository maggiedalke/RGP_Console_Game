# Text Adventure RPG

I created an RPG game, where you are a hero and you are fighting monsters. <br>

The game starts with asking about our name, then it presents the user with the following options:<br>
- Show our statistics (like number of games we played so far, number of games we won so
far…etc)
- Show our inventory (like what weapons and armors we currently have)
- Fight! (it will start a fighting game between us and a random monster from a list of monsters)
- Quit! (The user can choose to leave the game)

## Development Process 
 
 The game has the following classes:<br>

### Hero Class
- which represents us (the player), the hero has the following properties:
  * Name
  * Base Strength (will be added to the weapon’s strength to calculate attacks damage)
  * Base Defense (will be added to the armor’s defense to calculate the defense against each attack)
  * OriginalHealth (Hit Points)
  * CurrentHealth
  * EquippedWeapon
  * EquippedArmor
  * ArmorsBag
  * WeaponsBag
And the following functions:
  * Show Stats
  * Show Inventory
  * Equip Weapon
  * Equip Armor <p>
### Monster Class
- which has the following properties:
  * Name
  * Strength
  * Defense
  * OriginalHealth
  * CurrentHealth

### Weapon and Armor classes 
Both have a **Name** and a **power** property<br>

### Fight class 
This class is responsible for organizing the fight, so there should be a function for the
*hero turn*, *monster turn*, *Win* and *Lose* functions, of course you win if the monster died, and you
lose if you died first(your Health == 0)
* The attack damage of the user is (User Strength + Equipped weapon strength)
* The Defense property means how much HP you can block with EACH received attack
* The Defense of the user is (User Defense + Equipped Armor defense)<br>

- Game class, it will show the main menu for us, and it will have a proper function call for each
option in the main menu (switch statement), once you finish an option (like showing your stats),
you should be able to go back to the main menu without restarting the application.
- Inside the main function (class Program), we just want to create an object (game) from Game
class, then call game.Start().
- The user can choose to fight the strongest (top damage or top defense) monster
- A Hero can earn coins if he won a match, he can use those coins to buy Health during the game.

## How to use
This app has to be run in Visual Studio. Once you have all the code, you will **start the console**. <br>
**The app is entirely keyboard-based, and the app will assist you in determining which keys to press.**

The user will enter a name and the main menu will come up. <br>
The main menu consists of 4 choices. 
- **Current Stats**
- **Show Inventory**
- **Fight**
- **Quit**

Below is the function of each choice:

**Current Stats** will allow the user to see information such as:
- How many games won/lost/tied/played
- current armor and weapon
- Health/Defense/Strength 
- Weapons/Armor Bag

**Show Inventory** will allow the user to view their equipped armor and weapon. This is where the user can look in their armor/weapons bag and change any equipment. 

**Fight** will start a fight. <br>
During a fight you will fight a cluster of random monsters - 1 at a time. <br>
**Features of the fight include**:
- gaining experience, 
- gaining coins for a win. 
- dropping coins for a lose
- spending coins to buy healing potions. 

**Quit** - The game will continue to run until you choose to quit or close the console. 
