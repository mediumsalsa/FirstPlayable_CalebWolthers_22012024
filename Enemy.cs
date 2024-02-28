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

        public char enemyChar;

        public int health;

        public int enemyDamage;

        public string enemyDir;

        public int moveTick;

        public string enemyName;

        public static int enemyHealth;


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
            ey.enemyDamage = dmg;
            ey.enemyDir = direction;

            Map.map[ey.enemyPosY, ey.enemyPosX] = ey.enemyChar;


        }



        //Bounces vertically
        public static void MoveEnemyVert(Enemy ey)
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

        //Moves randomly
        public static void MoveEnemyRandom(Enemy ey)
        {

            if (ey.enemyChar != '`')
            {
                var rd = new Random();
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


        //Moves randomly
        public static void MoveEnemyRandom2(Enemy ey)
        {

            if (ey.enemyChar != '`')
            {
                var rand = new Random();
                int dir = rand.Next(0, 400);

                //Up
                if  (dir > 300)
                {
                    EnemyMove(ey, 0, -1, null);
                }

                //Left
                else if (dir > 200 && dir <= 300)
                {
                    EnemyMove(ey, -1, 0, null);
                }

                //Down
                else if (dir > 100 && dir <= 200)
                {
                    EnemyMove(ey, 0, 1, null);
                }

                //Right
                else if (dir <= 100)
                {
                    EnemyMove(ey, 1, 0, null);
                }

            }
        }

        //Moves randomly diagnolly
        public static void MoveEnemyRandomDiagonol(Enemy ey)
        {

            if (ey.enemyChar != '`')
            {
                var rand = new Random();
                int dir = rand.Next(0, 400);

                //Up
                if (dir > 300)
                {

                }

                //Left
                else if (dir > 200 && dir <= 300)
                {

                }

                //Down
                else if (dir > 100 && dir <= 200)
                {

                }

                //Right
                else if (dir <= 100)
                {

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

            if (Map.map[enemyNextPosY, ey.enemyPosX] == '`' || Map.map[ey.enemyPosY, enemyNextPosX] == '`')
            {
                ey.enemyPosX += nextX;
                ey.enemyPosY += nextY;
                EnemyAfterMove(ey);
            }
            else if (Map.map[enemyNextPosY, ey.enemyPosX] == Player.gameChar || Map.map[ey.enemyPosY, enemyNextPosX] == Player.gameChar && ey.enemyChar != '`')
            {
                EnemyHitsPlayer(ey);
            }
            else
            {
                ey.enemyDir = nextDir;
            }

        }



        //If player isnt deat, hit player
        static void EnemyHitsPlayer(Enemy ey)
        {
            if (ey.health >= 0)
            {
                HealthSystem.TakeDamage("player", ey.enemyDamage, ref Player.health, null);
                Map.UpdateHUD(ey);
            }
        }



        //Move enemy and replace last position
        static void EnemyAfterMove(Enemy ey)
        {
            Map.map[enemyLastPosY, enemyLastPosX] = '`';

            Map.map[ey.enemyPosY, ey.enemyPosX] = ey.enemyChar;
        }




    }
}
