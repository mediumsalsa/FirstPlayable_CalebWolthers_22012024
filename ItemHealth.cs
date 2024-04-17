using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class ItemHealth : Item
    {

        private Player player;
        private Map map;
        private int healAmount;

        public ItemHealth(Map map, Player player) : base(map, player)
        {
            this.map = map;
            this.player = player;
            name = "Health Potion";
            Char = '@';
            healAmount = 30;
            delete = false;
        }


        public override void DoYourJob()
        {
            if (delete == false)
            {
                player.healthSystem.Heal(healAmount);
                delete = true;
            }
        }

        public override void Update()
        {
            if (delete == true)
            {
                map.map[posY, posX] = '`';
                Char = '`';
            }
        }

        public override void Draw()
        {
            map.map[posY, posX] = Char;
        }

    }
}
