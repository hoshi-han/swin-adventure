using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class TakeCommand : Command
    {
        public TakeCommand() : base(new string[] { "pickup", "take" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            if (AreYou("pickup") || AreYou("take"))
            {
                IHaveInventory container = null;

                if (text.Length == 1 && (text[0].ToLower() != "take" || text[0].ToLower() != "pickup"))
                {
                    return "What do you want to pick up?";
                }

                if (text.Length == 2)
                {
                    container = p.Location as IHaveInventory;
                }
                else if (text.Length == 4)
                {
                    if (text[2].ToLower() != "from")
                    {
                        return "Where do you want to take from?";
                    }
                    container = FetchContainer(p, text[3]) as IHaveInventory;
                }
                else
                {
                    return "I don't know how to pick up like that";
                }


                return PickUp(p, text[1], container);
            }
            else
            {
                return "Error in pickup input";
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

        private string PickUp(Player p, string thingId, IHaveInventory container)
        {
            if (container != null)
            {
                Item itm = container.Locate(thingId) as Item;
                if (itm != null)
                {
                    p.Inventory.Put(itm);
                    container.RemoveFromInventory(itm);
                    return $"You picked up {itm.Name}.";
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
