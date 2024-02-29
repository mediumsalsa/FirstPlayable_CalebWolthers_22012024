using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Enemy : Entity
    {

        public char enemyChar = 'Q';

        public int health = 100;

        public int enemyDamage = 20;

        public string enemyDir = "right";

        public string enemyName = "Enemy";

        private static Random rd = new Random();

        static int randomX;
        static int randomY;

        //
        public int enemyPosX = randomX;
        public int enemyPosY = randomY;
        //
        public static int enemyNextPosX;
        public static int enemyNextPosY;
        //
        public static int enemyLastPosX;
        public static int enemyLastPosY;
        //

        public static void SetEnemy(Enemy ey, string name, int posX, int posY, char icon, int health, int dmg, string direction)
        { 
            ey.enemyName = name;
            ey.enemyPosX = posX;
            ey.enemyPosY = posY;
            ey.enemyChar = icon;
            ey.health = health;
            ey.enemyDamage = dmg;
            ey.enemyDir = direction;

            Map.map[ey.enemyPosY, ey.enemyPosX] = ey.enemyChar;
        }



        //Bounce in a square
        public static void MoveEnemySquare(Enemy ey)
        {

            if (ey.enemyChar != '`')
            {

                //Up
                if (ey.enemyDir == "up")
                {
                    EnemyMove(ey, 0, -1, "left");
                }
                //Left
                else if (ey.enemyDir == "left")
                {
                    EnemyMove(ey, -1, 0, "down");
                }
                //Down
                else if (ey.enemyDir == "down")
                {
                    EnemyMove(ey, 0, 1, "right");
                }

                //Right
                else if (ey.enemyDir == "right")
                {
                    EnemyMove(ey, 1, 0, "up");
                }
            }
        }



        public static void EnemyMove(Enemy ey, int nextX, int nextY, string nextDir)
        {
            enemyNextPosX = ey.enemyPosX + nextX;
            enemyNextPosY = ey.enemyPosY + nextY;

            enemyLastPosY = ey.enemyPosY;
            enemyLastPosX = ey.enemyPosX;

            EnemyCheckNextMove(ey, nextDir);

            ey.enemyPosX = enemyNextPosX;
            ey.enemyPosY = enemyNextPosY;
            Map.map[enemyLastPosY, enemyLastPosX] = '`';
            Map.map[ey.enemyPosY, ey.enemyPosX] = ey.enemyChar;

        }


        public static void EnemyCheckNextMove(Enemy ey, string nextDir)
        {
            if (Map.map[enemyNextPosY, ey.enemyPosX] == '`' || Map.map[ey.enemyPosY, enemyNextPosX] == '`')
            {
                // :D
            }
            else if (Map.map[enemyNextPosY, ey.enemyPosX] == Player.gameChar || Map.map[ey.enemyPosY, enemyNextPosX] == Player.gameChar && ey.enemyChar != '`')
            {
                if (ey.health >= 0)
                {
                    EnemyCantMove();
                    HealthSystem.TakeDamage("player", ey.enemyDamage, ref Player.health, null);
                    Map.UpdateHUD(ey);
                }
            }
            else 
            {
                EnemyCantMove();
                ey.enemyDir = nextDir;
            }
        }


        public static void EnemyCantMove()
        {
            enemyNextPosY = enemyLastPosY;
            enemyNextPosX = enemyLastPosX;
        }



    }
}
