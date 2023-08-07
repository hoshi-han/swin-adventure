using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Inventory : GameObject
    {
        private List<Item> _items;

        public Inventory() : base(new string[] { "inventory" }, "inventory", "Player inventory")
        {
            _items = new List<Item>();
        }

        public List<Item> Items 
        { 
            get { return _items; } 
        }

        public bool HasItem(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }

        //Added to indicate if an inventory is empty or not
        public bool IsEmpty()
        {
            if (_items.Count == 0)
            {
                return true;
            } 
            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            Item itm = Fetch(id);
            if (itm != null)
            {
                _items.Remove(itm);
                return itm;
            }
            return null;
        }

        public Item Fetch(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
                {
                    return itm;
                }

            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string itemList = string.Empty;
                foreach (Item itm in _items)
                {
                    itemList += $"\t{itm.ShortDescription}\n";
                }
                return itemList;
            }   
        }
    }
}
