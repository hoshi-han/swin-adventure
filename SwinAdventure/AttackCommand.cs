using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class AttackCommand : Command
    {
        public AttackCommand() : base(new string[] { "attack", "fight" })
        {

        }

        public override string Execute(Player player, string[] text)
        {
            if (AreYou("attack") || AreYou("fight"))
            {
                if (text.Length == 1)
                {
                    return "What do you want to attack?";
                }
                else if (text.Length == 2)
                {
                    // Get the ID of the enemy the player wants to attack
                    string enemyId = text[1];
                    //Locate the enemy in the player's location
                    Enemy enemy = player.Location.Enemies.Find(e => e.AreYou(enemyId));

                    if (enemy == null)
                    {
                        return $"There is no {enemyId} to attack.";
                    }

                    // Player attacks the enemy
                    player.Attack(enemy);

                    // Check if the enemy is defeated
                    if (enemy.IsDefeated())
                    {
                        // Display enemy's inventory
                        string items = enemy.Inventory.ItemList;
                        string defeatMessage = $"You have defeated the {enemy.Name}!\n";
                        defeatMessage += $"It dropped the following items:\n{items}";

                        // Create a temporary list to store the items for transfer
                        List<Item> itemsToTransfer = new List<Item>();

                        // Transfer player's inventory to the location
                        foreach (Item item in enemy.Inventory.Items)
                        {
                            itemsToTransfer.Add(item);
                        }

                        // Remove the defeated enemy from the location
                        player.Location.Inventory.Take(enemyId);

                        // Transfer the items from the temporary list to the location's inventory
                        foreach (Item item in itemsToTransfer)
                        {
                            player.Location.Inventory.Put(item);
                            enemy.RemoveFromInventory(item);
                        }
                    }
                    else
                    {
                        // Enemy attacks the player
                        enemy.DoDamage(player);

                        // Output the remaining health of the enemy
                        return $"You attack the {enemy.Name} and deal {player.Damage} damage.\n" +
                               $"The {enemy.Name} has {enemy.Health} health remaining.\n" +
                               $"The {enemy.Name} counterattacks and deals {enemy.Damage} damage.\n" +
                               $"Your health: {player.Health}\n" +
                               $"Enemy's health: {enemy.Health}\n";
                    } 


                }
                else if (text.Length == 4 && text[2].ToLower() == "with")
                {
                    // Get the ID of the weapon the player wants to attack with
                    string weaponId = text[3];
                    // Get the ID of the enemy the player wants to attack
                    string enemyId = text[1];
                    //Locate the enemy in the player's location
                    Enemy enemy = player.Location.Enemies.Find(e => e.AreYou(enemyId));
                    //Fetch the weapon from the player's inventory
                    Weapon weapon = player.Inventory.Fetch(weaponId) as Weapon;

                    // Check if the enemy is there
                    if (enemy == null)
                    {
                        return $"There is no {enemyId} to attack.";
                    }

                    // Check if the player has the weapon
                    if (weapon == null)
                    {
                        return $"You don't have a {weaponId} to attack with.";
                    }

                    // Player attacks the enemy with the weapon
                    weapon.Attack(enemy);

                    // Check if the enemy is defeated
                    if (enemy.IsDefeated())
                    {
                        // Display enemy's inventory
                        string items = enemy.Inventory.ItemList;
                        string defeatMessage = $"You have defeated the {enemy.Name}!\n";
                        defeatMessage += $"It dropped the following items:\n{items}";

                        // Create a temporary list to store the items for transfer
                        List<Item> itemsToTransfer = new List<Item>();

                        // Transfer player's inventory to the location
                        foreach (Item item in enemy.Inventory.Items)
                        {
                            itemsToTransfer.Add(item);
                        }

                        // Remove the defeated enemy from the location
                        player.Location.Inventory.Take(enemyId);

                        // Transfer the items from the temporary list to the location's inventory
                        foreach (Item item in itemsToTransfer)
                        {
                            player.Location.Inventory.Put(item);
                            enemy.RemoveFromInventory(item);
                        }

                        return defeatMessage;
                    }
                    else
                    {
                        // Enemy attacks the player
                        enemy.DoDamage(player);

                        // Output the remaining health of the enemy and player
                        return $"You attack the {enemy.Name} with the {weapon.Name} and deal {weapon.Damage} damage.\n" +
                               $"The {enemy.Name} has {enemy.Health} health remaining.\n" +
                               $"The {enemy.Name} counterattacks and deals {enemy.Damage} damage.\n" +
                               $"Your health: {player.Health}\n" +
                               $"Enemy's health: {enemy.Health}\n";
                    }
                }
            }

            return "Whaa? I didn't hear you. (said your consciousness)";
        }
    }
}
