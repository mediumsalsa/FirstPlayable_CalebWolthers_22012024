using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class ItemInvincible : Item
    {
        public static int originalShield = Player.shield;

        public static new char itemChar = Settings.invincibilityChar;

        public static int effectTime = Settings.invincibilityEffectTime;

        public static string name = Settings.invincibilityName;

        public static async Task Invincibility()
        {
            int originalHealth = Player.shield;

            Player.shield = 99999999;

            UI.lastItem = "Invincibility";

            await Task.Delay(effectTime);

            Player.shield = originalShield;
        }
    }
}
