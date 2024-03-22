﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class EnemyOrc : Enemy
    {

        public EnemyOrc()
        {
            enemyName = "Orc";
            enemyChar = 'O';
            enemyHealth = 200;
            enemyDamage = 40;
            enemyDir = null;

            enemyMinX = 60;
            enemyMaxX = Map.width - 2;
            enemyMinY = 10;
            enemyMaxY = Map.height - 2;

        }


        private static Random rd = new Random();


        //Moves randomly
        public override void MoveEnemy(Enemy ey)
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
