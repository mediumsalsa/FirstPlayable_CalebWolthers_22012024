using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal abstract class Item
    {

        private Map map;
        private Player player;
        public char Char;
        public string name;
        public int posX;
        public int posY;
        public bool delete;

        public Item(Map map, Player player)
        {
            this.map = map;
            this.player = player;
        }

        public abstract void DoYourJob();

        public abstract void Update();

        public abstract void Draw();

    }
}
