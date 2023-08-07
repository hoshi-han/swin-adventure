using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;
        //Integer that specifies the player's current health
        private int _health;
        //Integer that specifies the player's maximum health
        private int _maxHealth;
        //Integer that specifies the player's damage output
        private int _damage;

        public Player(string name, string desc, int health, int damage) : base(new string[] { "me", "inventory", "inv" }, name, desc)
        {
            _inventory = new Inventory();
            _maxHealth = health;
            _health = health;
            _damage = damage;   
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public Location Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                if (_health > _maxHealth)
                    _health = _maxHealth;
            }
        }
            
        public int MaxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }

        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
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

        //Takes away a number from an Enemy's health based on the Player's Damage variabl
        public void Attack(Enemy enemy)
        {
            enemy.Health -= Damage;
        }

        public override string FullDescription
        {
            get
            {
                string playerDescription = base.FullDescription;
                string inventoryDescription = $"You are carrying:\n {_inventory.ItemList}";

                return $"You are: {playerDescription}\n{inventoryDescription}";
            }
        }
    }
}