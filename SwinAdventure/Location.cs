using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private string _name;
        private string _desc;
        private Path _path;
        //List of the Enemy class that indicates the enemies in the location
        private List<Enemy> _enemies;
        
        public Location(string[] ids, string name, string desc, Path path, List<Enemy> enemies) : base(ids, name, desc)
        {
            _inventory = new Inventory();
            _name = name;
            _desc = desc;
            _path = path;
            _enemies = enemies ?? new List<Enemy>();
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

        //Adds an enemy to the Enemies list
        public void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
        }

        public Path Path
        {
            get { return _path; }
            set { _path = value; }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _desc; }
        }

        public List<Enemy> Enemies
        {
            get { return _enemies; }
            set { _enemies = value; }
        }
    }
}
