using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class DropCommand : Command
    {
        public DropCommand() : base(new string[] { "put", "drop" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            if (AreYou("put") || AreYou("drop"))
            {
                IHaveInventory container = null;

                if (text.Length == 1 && (text[0].ToLower() != "put" || text[0].ToLower() != "drop"))
                {
                    return "What do you want to drop?";
                }

                if (text.Length == 2)
                {
                    container = p as IHaveInventory;
                }
                else if (text.Length == 4)
                {
                    if (text[2].ToLower() != "from")
                    {
                        return "Where do you want to drop from?";
                    }
                    container = FetchContainer(p, text[3]) as IHaveInventory;
                }
                else
                {
                    return "I don't know how to drop like that";
                }


                return Drop(p, text[1], container, text);
            }
            else
            {
                return "Error in drop input";
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

        private string Drop(Player p, string thingId, IHaveInventory container, string[] text)
        {
            if (container != null)
            {
                Item itm = container.Locate(thingId) as Item;
                if (itm != null)
                {
                    p.Inventory.Take(itm.FirstId);
                    if (text.Length == 2)
                    {     
                        p.Location.AddToInventory(itm);
                    } else if (text.Length == 4) 
                    { 
                        container.AddToInventory(itm);
                    }
                    return $"You dropped {itm.Name}.";
                }
                else
                {
                    return $"I cannot locate the {thingId} :(";
                }
            }
            else
            {
                return "I cannot locate the container :(";
            }
        }
    }
}
