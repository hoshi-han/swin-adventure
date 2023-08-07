using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory;
        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            else
            {
                return null;
            }
        }

        public void RemoveFromInventory(GameObject item)
        {
            _inventory.Take(item.FirstId);
        }

        public void AddToInventory(Item item)
        {
            _inventory.Put(item);
        }

        public override string FullDescription 
        {
            get
            {
                string bagDescription = $"In the {Name} you can see:\n {Inventory.ItemList}";

                return bagDescription;
            }
        }
        public Inventory Inventory
        {
            get { return _inventory; }
        }
    }
}
