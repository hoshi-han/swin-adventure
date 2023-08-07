using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class UseCommand : Command
    {
        public UseCommand() : base(new string[] { "use", "eat", "drink", "consume" })
        {

        }

        public override string Execute(Player player, string[] text)
        {
            if (AreYou("use") || AreYou("eat") || AreYou("drink") || AreYou("consume"))
            {
                if (text.Length == 1)
                {
                    return "What do you want to use?";
                }
                else if (text.Length == 2)
                {
                    // Get the ID of the item the player wants to use
                    string itemId = text[1];

                    // Locate the item in the player's inventory
                    Item item = player.Locate(itemId) as Item;

                    // Check if the player has the item
                    if (item == null)
                    {
                        return $"You don't have a(n) {itemId} to use.";
                    }

                    // Execute the specific use behavior based on the type of item
                    if (item is HealingItem)
                    {
                        // Cast the item to the specific type (HealingItem) to access its properties
                        HealingItem healingItem = item as HealingItem;

                        // Use the healing item, restoring player's health
                        healingItem.Use(player);

                        // Remove the used healing item from the player's inventory
                        player.RemoveFromInventory(healingItem);

                        // Return a message indicating the effect of using the healing item
                        return $"You have used the {healingItem.Name} and restored {healingItem.HealAmount} health.\nYour current health: {player.Health}\n";
                    }

                    if (item is UpgradeItem)
                    {
                        // Cast the item to the specific type (UpgradeItem) to access its properties
                        UpgradeItem upgradeItem = item as UpgradeItem;

                        // Use the upgrade item, permanently upgrading player's stats
                        upgradeItem.Use(player);

                        // Remove the used upgrade item from the player's inventory
                        player.RemoveFromInventory(upgradeItem);

                        // Return a message indicating the effect of using the upgrade item
                        return $"You have used the {upgradeItem.Name} and permanently gained an additional {upgradeItem.UpgradeAmountH} Health Points and {upgradeItem.UpgradeAmountD} Damage.\nMax Health: {player.MaxHealth}\nBase Damage: {player.Damage}\n";
                    }

                    // If the item is not a registered item type, return an error message
                    return $"You cannot use the {item.Name}.";
                }
            }

            return "Whaa? I didn't hear you. (said your consciousness)";
        }
    }
}
