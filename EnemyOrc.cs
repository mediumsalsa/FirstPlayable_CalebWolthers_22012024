using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace FirstPlayable_CalebWolthers_22012024
{
    internal class EnemyOrc : Enemy
    {

        public EnemyOrc()
        {
            enemyName = Settings.orcName;
            enemyChar = Settings.orcChar;
            enemyHealth = Settings.orcHealth;
            enemyDamage = Settings.orcDamage;

            enemyMinX = Settings.orcMinX;
            enemyMaxX = Settings.orcMaxX;
            enemyMinY = Settings.orcMinY;
            enemyMaxY = Settings.orcMaxY;

        }


        private static Random rd = new Random();


        //Moves randomly
        public override void Update(Enemy ey)
        {
            if (ey.enemyChar != '`')
            {

                int dir = rd.Next(0, 400);

                //Up
                if (dir <= 100)
                {
                    EnemyMove(ey, 0, -1, null);
                }
                //Left
                else if (dir > 100 && dir <= 200)
                {
                    EnemyMove(ey, -1, 0, null);
                }
                //Down
                else if (dir > 200 && dir <= 300)
                {
                    EnemyMove(ey, 0, 1, null);
                }
                //Right
                else if (dir > 300)
                {
                    EnemyMove(ey, 1, 0, null);
                }
            }
        }


    }
}
*/