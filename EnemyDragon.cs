using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class EnemyDragon : Enemy
    {

        private static Random rd = new Random();


        public static void MoveEnemyRandom(Enemy ey)
        {
            if (ey.enemyChar != '`')
            {

                int dir = rd.Next(0, 800);

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
                else if (dir > 300 && dir <= 400)
                {
                    EnemyMove(ey, 1, 0, null);
                }
                //Up Left
                else if (dir > 400 && dir <= 500)
                {
                    EnemyMove(ey, -2, -2, null);
                }
                //Left Down
                else if (dir > 500 && dir <= 600)
                {
                    EnemyMove(ey, -2, 2, null);
                }
                //Down Right
                else if (dir > 600 && dir <= 700)
                {
                    EnemyMove(ey, 2, 2, null);
                }
                //Right Up
                else if (dir > 800)
                {
                    EnemyMove(ey, 2, -2, null);
                }
            }
        }

    }
}
