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


        public static void StartItems()
        {
            for (int i = 0; i < numberOfHealthPotions; i++)
            {
                healthPotions[i] = new ItemHealth();
                Item.RandomlyPlaceItem(healthPotions[i], "Health Potion", '@', 2, Map.width - 2, 2, Map.height - 2);
            }
        }

    }
}
