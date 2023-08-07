using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public interface IHaveInventory
    {
        public GameObject Locate(string id);
        void RemoveFromInventory(GameObject item);
        void AddToInventory(Item item);
        public string Name
        {
            get;
        }
    }
}
