using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class EnemyDragon : Enemy
    {
        public static new string enemyName = "Dragon";
        public static new char enemyChar = 'D';
        public static new int enemyHealth = 10000;
        public static new int enemyDamage = 100;
        public static new string enemyDir;

        public static new int enemyPosX = 92;
        public static new int enemyPosY = 1;

        public static new int enemyMinX = 2;
        public static new int enemyMaxX = Map.width - 85;
        public static new int enemyMinY = 1;
        public static new int enemyMaxY = Map.height - 24;




        private static Random rd = new Random();

        public override void MoveEnemy(Enemy ey)
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
