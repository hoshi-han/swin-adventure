using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class HealingItem : Item
    {
        //Integer that indicates the amount of health the item restores
        private int _healAmount;

        public HealingItem(string[] ids, string name, string desc, int healAmount) : base(ids, name, desc)
        {
            _healAmount = healAmount;
        }

        public int HealAmount
        {
            get { return _healAmount; }
            set { _healAmount = value; }
        }

        // Restore the player's health by the heal amount
        public override void Use(Player player)
        {
            player.Health += _healAmount;
        }
    }
}
