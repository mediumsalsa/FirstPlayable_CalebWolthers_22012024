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
            enemyName = Settings.goblinName;
            enemyChar = Settings.goblinChar;
            enemyHealth = Settings.goblinHealth;
            enemyDamage = Settings.goblinDamage;
            enemyDir = Settings.goblinDir;

            enemyMinX = Settings.goblinMinX;
            enemyMaxX = Settings.goblinMaxX;
            enemyMinY = Settings.goblinMinY;
            enemyMaxY = Settings.goblinMaxY;


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
