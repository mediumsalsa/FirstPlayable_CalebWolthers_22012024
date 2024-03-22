using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class ItemHealth : Item
    {
        public static new char itemChar = '@';

        public static void HealPlayer()
        {
            UI.lastItem = "Health Potion(+30 health)";
            HealthSystem.Heal(30, ref Player.health);
        }
    }
}
