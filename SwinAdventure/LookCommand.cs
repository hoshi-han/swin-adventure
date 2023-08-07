using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] {"look"})
        {

        }

        public override string Execute(Player p, string[] text)
        {
            if (text[0].ToLower() == "look")
            {
                IHaveInventory container = null;

                if (text.Length == 1)
                {
                    // Create a string to store the location information
                    string output = "You are currently at " + p.Location.Name + "\n" + p.Location.Description + "\n";

                    // Check if the location's inventory is not empty
                    if (!p.Location.Inventory.IsEmpty())
                    {
                        // Add a list of items in the location's inventory to the output
                        output += "In this location you can see:\n" + p.Location.Inventory.ItemList;
                    }
                    else
                    {
                        // If the location's inventory is empty, indicate that there are no items visible
                        output += "You can't see any items.\n";
                    }

                    // Check if the location has any enemies
                    if (p.Location.Enemies != null)
                    {
                        // Add a list of enemy names to the output
                        output += "There's something you can fight: ";
                        foreach (Enemy enemy in p.Location.Enemies)
                        {
                            output += enemy.Name + "\n";
                        }
                    }
                    else
                    {
                        // If there are no enemies, indicate that there are no enemies in the location
                        output += "There are no enemies here.";
                    }

                    // Return the final output containing the location information
                    return output;
                }

                if (text.Length == 3)
                {
                    container = p as IHaveInventory;
                }
                else if (text.Length == 5)
                {
                    if (text[3].ToLower() != "in")
                    {
                        return "What do you want to look in?";
                    }
                    container = FetchContainer(p, text[4]) as IHaveInventory;
                }
                else
                {
                    return "I don't know how to look like that";
                }

                return LookAtIn(text[2], container);
            }
            else
            {
                return "Error in look input";
            }
        }

        private IHaveInventory FetchContainer(Player p, string containerId) 
        {
            if (containerId != null)
            {
                return p.Locate(containerId) as IHaveInventory;
            }
            else
            {
                return null;
            }
        }

        private string LookAtIn(string thingId, IHaveInventory container) 
        { 
            if (container != null)
			{
				GameObject itm = container.Locate(thingId);
				if (itm != null)
				{
					return itm.FullDescription;
				}
				else {
					return $"I cannot locate the {thingId} :(";
				}
			}
			else {
				return "I cannot locate the container :(";
			}
        }
    }
}
