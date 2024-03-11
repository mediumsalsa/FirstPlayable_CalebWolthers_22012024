using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class EnemyGoblin : Enemy
    {
        public static new string enemyName = "Goblin";
        public static new char enemyChar = 'G';
        public static new int enemyHealth = 150;
        public static new int enemyDamage = 20;
        public static new string enemyDir = "down";

        public static new int enemyMinX = 8;
        public static new int enemyMaxX = Map.width - 70;
        public static new int enemyMinY = 16;
        public static new int enemyMaxY = Map.height - 2;


        //Bounces vertically
        public override void MoveEnemy(Enemy ey)
        {
            if (ey.enemyChar != '`')
            {
                //Up
                if (ey.enemyDir == "up")
                {
                    EnemyMove(ey, 0, -1, "down");
                }
                //Down
                else if (ey.enemyDir == "down")
                {
                    EnemyMove(ey, 0, 1, "up");
                }
            }
        }

    }
}
