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



        public static void SetEnemy(string name, int posX, int posY, char icon, int health, int dmg, string direction, int tick)
        {
            var ey = new Enemy();
            ey.enemyName = name;
            ey.enemyPosX = posX;
            ey.enemyPosY = posY;
            ey.enemyChar = icon;
            ey.health = health;
            ey.enemyDamage = dmg;
            ey.enemyDir = direction;
            ey.moveTick = tick;
            Map.map[ey.enemyPosY, ey.enemyPosX] = ey.enemyChar;


        }

        public static void UpdateEnemy(Enemy ey)
        {
            SetEnemy(ey.enemyName, ey.enemyPosX, ey.enemyPosY, ey.enemyChar, ey.health, ey.enemyDamage, ey.enemyDir, ey.moveTick);
        }


        //Bounces vertically
        public static void MoveEnemyVert(Enemy ey)
        {
            if (ey.enemyChar != '`')
            {

                //Up
                if (ey.enemyDir == "up")
                {
                    EnemyMoveUp(ey, "down");
                }

                //Down
                else if (ey.enemyDir == "down")
                {
                    EnemyMoveDown(ey, "up");
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
                    EnemyMoveUp(ey, null);
                }

                //Left
                else if (dir > 100 && dir <= 200)
                {
                    EnemyMoveLeft(ey, null);
                }

                //Down
                else if (dir > 200 && dir <= 300)
                {
                    EnemyMoveDown(ey, null);
                }

                //Right
                else if (dir > 300)
                {
                    EnemyMoveRight(ey, null);
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
                    EnemyMoveUp(ey, null);
                }

                //Left
                else if (dir > 200 && dir <= 300)
                {
                    EnemyMoveLeft(ey, null);
                }

                //Down
                else if (dir > 100 && dir <= 200)
                {
                    EnemyMoveDown(ey, null);
                }

                //Right
                else if (dir <= 100)
                {
                    EnemyMoveRight(ey, null);
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
                    EnemyMoveUp(ey, null);
                    EnemyMoveLeft(ey, null);
                }

                //Left
                else if (dir > 200 && dir <= 300)
                {
                    EnemyMoveDown(ey, null);
                    EnemyMoveLeft(ey, null);
                }

                //Down
                else if (dir > 100 && dir <= 200)
                {
                    EnemyMoveDown(ey, null);
                    EnemyMoveRight(ey, null);
                }

                //Right
                else if (dir <= 100)
                {
                    EnemyMoveUp(ey, null);
                    EnemyMoveRight(ey, null);
                }
            }
        }

        //Moves in a chatotic patterm
        public static void MoveEnemyPatrol(Enemy ey)
        {
            if (ey.enemyChar != '`')
            {

                //Up
                if (ey.enemyDir == "up")
                {
                    EnemyMoveUp(ey, "right");
                    ey.moveTick++;
                    if (ey.moveTick >= 8)
                    {
                        ey.moveTick = 0;
                        ey.enemyDir = "down";
                    }
                }

                //Left
                else if (ey.enemyDir == "left")
                {
                    EnemyMoveLeft(ey, "down");
                    ey.moveTick++;
                    if (ey.moveTick >= 6)
                    {
                        ey.moveTick = 0;
                        ey.enemyDir = "left";
                    }
                }

                //Down
                else if (ey.enemyDir == "down")
                {
                    EnemyMoveDown(ey, "up");
                    ey.moveTick++;
                    if (ey.moveTick >= 4)
                    {
                        ey.moveTick = 0;
                        ey.enemyDir = "right";
                    }
                }

                //Right
                else if (ey.enemyDir == "right")
                {
                    EnemyMoveRight(ey, "left");
                    ey.moveTick++;
                    if (ey.moveTick >= 4)
                    {
                        ey.moveTick = 0;
                        ey.enemyDir = "up";
                    }
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
                    EnemyMoveUp(ey, "left");
                }

                //Left
                else if (ey.enemyDir == "left")
                {
                    EnemyMoveLeft(ey, "down");
                }

                //Down
                else if (ey.enemyDir == "down")
                {
                    EnemyMoveDown(ey, "right");
                }

                //Right
                else if (ey.enemyDir == "right")
                {
                    EnemyMoveRight(ey, "up");
                }
            }
        }




        //Next 4 methods make the enemy move in any of the 4 cardinal directions
        //

        //Moves enemy up
        public static void EnemyMoveUp(Enemy ey, string nextDir)
        {
            enemyNextPosY = ey.enemyPosY - 1;

            enemyLastPosY = ey.enemyPosY;
            enemyLastPosX = ey.enemyPosX;

            if (Map.map[enemyNextPosY, ey.enemyPosX] == '`')
            {
                ey.enemyPosY--;
                EnemyAfterMove(ey);
            }
            else if (Map.map[enemyNextPosY, ey.enemyPosX] == 'P' && ey.enemyChar != '`')
            {
                EnemyHitsPlayer(ey);
            }
            else
            {
                ey.enemyDir = nextDir;
            }
        }


        //Moves enemy left
        public static void EnemyMoveLeft(Enemy ey, string nextDir)
        {
            enemyNextPosX = ey.enemyPosX - 1;

            enemyLastPosY = ey.enemyPosY;
            enemyLastPosX = ey.enemyPosX;

            if (Map.map[ey.enemyPosY, enemyNextPosX] == '`')
            {
                ey.enemyPosX--;
                EnemyAfterMove(ey);
            }
            else if (Map.map[ey.enemyPosY, enemyNextPosX] == 'P' && ey.enemyChar != '`')
            {
                EnemyHitsPlayer(ey);
            }
            else
            {
                ey.enemyDir = nextDir;
            }
        }


        //Moves enemy down
        public static void EnemyMoveDown(Enemy ey, string nextDir)
        {
            enemyNextPosY = ey.enemyPosY + 1;

            enemyLastPosY = ey.enemyPosY;
            enemyLastPosX = ey.enemyPosX;

            if (Map.map[enemyNextPosY, ey.enemyPosX] == '`')
            {
                ey.enemyPosY++;
                EnemyAfterMove(ey);
            }
            else if (Map.map[enemyNextPosY, ey.enemyPosX] == 'P' && ey.enemyChar != '`')
            {
                EnemyHitsPlayer(ey);
            }
            else
            {
                ey.enemyDir = nextDir;
            }
        }


        //Moves enemy right
        public static void EnemyMoveRight(Enemy ey, string nextDir)
        {
            enemyNextPosX = ey.enemyPosX + 1;

            enemyLastPosY = ey.enemyPosY;
            enemyLastPosX = ey.enemyPosX;

            if (Map.map[ey.enemyPosY, enemyNextPosX] == '`')
            {
                ey.enemyPosX++;
                EnemyAfterMove(ey);
            }
            else if (Map.map[ey.enemyPosY, enemyNextPosX] == 'P' && ey.enemyChar != '`')
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
