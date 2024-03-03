using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Item
    {

        public char itemChar;

        public string itemName;

        public int itemPosX;
        public int itemPosY;


        public static void SetItem(Item it, string name, int posX, int posY, char icon)
        {
            it.itemName = name;
            it.itemPosX = posX;
            it.itemPosY = posY;
            it.itemChar = icon;

            Map.map[it.itemPosY, it.itemPosX] = it.itemChar;
        }

        public static void RandomlyPlaceItem(Item it, string name, char icon, int minX, int maxX, int minY, int maxY)
        {
            Random random = new Random();

            while (true)
            {
                int x = random.Next(minX, maxX);
                int y = random.Next(minY, maxY);

                if (Map.map[y, x] == '`')
                {
                    SetItem(it, name, x, y, icon);
                    break;
                }
            }
        }



    }
}
