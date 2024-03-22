using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class EnemyGoblin : Enemy
    {

        public EnemyGoblin()
        {
            enemyName = "Goblin";
            enemyChar = 'G';
            enemyHealth = 150;
            enemyDamage = 20;
            enemyDir = "down";

            enemyMinX = 8;
            enemyMaxX = Map.width - 70;
            enemyMinY = 16;
            enemyMaxY = Map.height - 2;


        }


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
