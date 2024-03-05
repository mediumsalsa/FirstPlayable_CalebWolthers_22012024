using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Enemy
    {

        public char enemyChar;

        public int health;

        public int maxHealth;

        public int enemyDamage;

        public string enemyDir;

        public string enemyName;

        public static int enemyCount;

        //
        public int enemyPosX;
        public int enemyPosY;
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
            ey.maxHealth = health;
            ey.enemyDamage = dmg;
            ey.enemyDir = direction;


            Map.map[ey.enemyPosY, ey.enemyPosX] = ey.enemyChar;
        }

        //Places the orcs randomly on the map
        public static void RandomlyPlaceEnemy(Enemy enemy, string name, char icon, int health, int damage, string dir, int minX, int maxX, int minY, int maxY)
        {
            Random random = new Random();

            while (true)
            {
                int x = random.Next(minX, maxX);
                int y = random.Next(minY, maxY);

                if (Map.map[y, x] == '`')
                {
                    Enemy.SetEnemy(enemy, name, x, y, icon, health, damage, dir);
                    break;
                }
            }
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

        }

        public virtual void MoveEnemy(Enemy ey)
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


        public static void EnemyCheckNextMove(Enemy ey, string nextDir)
        {

            bool isWithinBounds = enemyNextPosX >= 0 && enemyNextPosX < Map.width && enemyNextPosY >= 0 && enemyNextPosY < Map.height;

            if (isWithinBounds && Map.map[enemyNextPosY, enemyNextPosX] == '`')
            {
                ey.enemyPosX = enemyNextPosX;
                ey.enemyPosY = enemyNextPosY;
                Map.map[enemyLastPosY, enemyLastPosX] = '`';
                Map.map[ey.enemyPosY, ey.enemyPosX] = ey.enemyChar;
            }
            else if (isWithinBounds && Map.map[enemyNextPosY, enemyNextPosX] == Player.gameChar && ey.enemyChar != '`')
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
