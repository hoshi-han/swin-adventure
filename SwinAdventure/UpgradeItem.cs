using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class UpgradeItem : Item
    {
        //Integer that indicates the amount of Health permanently added to the Player's stats
        private int _upgradeAmountH;
        //Integer that indicates the amount of Damage permanently added to the Player's stats
        private int _upgradeAmountD;

        public UpgradeItem(string[] ids, string name, string desc, int upgradeAmountH, int upgradeAmountD) : base(ids, name, desc)
        {
            _upgradeAmountH = upgradeAmountH;
            _upgradeAmountD = upgradeAmountD;
        }

        public int UpgradeAmountH
        {
            get { return _upgradeAmountH; }
            set { _upgradeAmountH = value; }
        }

        public int UpgradeAmountD
        {
            get { return _upgradeAmountD; }
            set { _upgradeAmountD = value; }
        }

        // Permanently upgrades the Player's stats
        public override void Use(Player player)
        {
            player.MaxHealth += _upgradeAmountH;
            player.Damage += _upgradeAmountD;
        }
    }
}
