using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Item : GameObjects
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



    }
}
