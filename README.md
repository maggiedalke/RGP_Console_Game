# Text Adventure RPG

We want to create an RPG game, like those games where you are a hero and you are fighting monsters. <br>

The game will start with asking about our name, then it will present us with the following options:<br>
- Show our statistics (like number of games we played so far, number of games we won so
far…etc)
- Show our inventory (like what weapons and armors we currently have)
- Fight! (it will start a fighting game between us and a random monster from a list of monsters)
<p>The game has the following classes:<br>

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

#### Notes:
- You can add any suitable properties and helper functions that you think are important to the
solution.
Bonus functions:
- The user can choose to fight the strongest (top damage or top defense) monster
- A Hero can earn coins if he won a match, he can use those coins to buy Health during the game.
