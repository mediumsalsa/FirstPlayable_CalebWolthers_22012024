using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class ItemManager
    {

        static int numberOfHealthPotions = 25;
        static ItemHealth[] healthPotions = new ItemHealth[numberOfHealthPotions];

        static int numberOfShields = 10;
        static ItemShield[] shields = new ItemShield[numberOfShields];

        static int numberOfInvincibility = 8;
        static ItemInvincible[] invincibles = new ItemInvincible[numberOfInvincibility];


        public static void StartItems()
        {
            for (int i = 0; i < numberOfHealthPotions; i++)
            {
                healthPotions[i] = new ItemHealth();
                Item.RandomlyPlaceItem(healthPotions[i], ItemHealth.name, ItemHealth.itemChar, 2, Map.width - 2, 2, Map.height - 2);
            }
            for (int i = 0; i < numberOfInvincibility; i++)
            {
                invincibles[i] = new ItemInvincible();
                Item.RandomlyPlaceItem(invincibles[i], ItemInvincible.name, ItemInvincible.itemChar, 2, Map.width - 2, 2, Map.height - 2);
            }
            for (int i = 0; i < numberOfShields; i++)
            {
                shields[i] = new ItemShield();
                Item.RandomlyPlaceItem(shields[i], ItemShield.name, ItemShield.itemChar, 2, Map.width - 2, 2, Map.height - 2);
            }


        }

    }
}
