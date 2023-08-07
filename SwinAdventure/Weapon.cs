using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Weapon : Item
    {
        //Integer that specifies the Weapon's damage output
        private int _damage;

        public Weapon(string[] ids, string name, string desc, int damage) : base(ids, name, desc)
        {
            _damage = damage;
        } 

        //Take away a certain amount of health from the Enemy
        public void Attack(Enemy enemy)
        {
            enemy.Health -= _damage;
        }

        public int Damage 
        { 
            get { return _damage; } 
            set { _damage = value; }
        }
    }
}
