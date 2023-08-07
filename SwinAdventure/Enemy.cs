using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Enemy : GameObject, IHaveInventory
    {
        //Integer that specifies the enemy's health
        private int _health;
        //Integer that specifies the enemy's damage output
        private int _damage;
        private Inventory _inventory;

        public Enemy(string[] ids, string name, string description, int health, int damage) : base(ids, name, description)
        {
            _health = health;
            _damage = damage;
            _inventory = new Inventory();
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int Damage
        {
            get { return _damage; }
        }

        public Inventory Inventory 
        {   
            get { return _inventory; } 
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

        //Takes away an integer's amount from the Enemy's health
        public void TakeDamage(int amount)
        {
            _health -= amount;
        }

        //Takes away a Player's health based on the Enemy's damage output
        public void DoDamage(Player p)
        {
            p.Health -= Damage;
        }

        //Boolean that indicates if the Enemy is defeated or not
        public bool IsDefeated()
        {
            if (_health < 0 || _health == 0)
            {
                return true;
            }
            return false;
        }
    }
}
