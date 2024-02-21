using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Player : Entity
    {


        public static int health = 100;

        public int xp;
        public int level;
        public int score;

        public static int playerPosX;
        public static int playerPosY;

        public static int nextPosX;
        public static int nextPosY;

        public static int lastPosX;
        public static int lastPosY;

        public static int oldPosX;
        public static int oldPosY;

        public static void SetPlayer()
        {
            Player.health = 100;

            Player.gameChar = 'P';

            playerPosX = 10;
            playerPosY = 10;
        }





        public static void KeyW()
        {
            var ey = new Enemy();
            nextPosY = playerPosY - 1;

            lastPosY = playerPosY;
            lastPosX = playerPosX;

            if (playerPosY != 0 && Map.map[nextPosY, playerPosX] != '#' && Map.map[nextPosY, playerPosX] != '~')
            { 

                if (Map.map[nextPosY, playerPosX] == '0')
                {
                    HealthSystem.TakeDamage("enemy", 60, ref ey.health);
                }
                else if (Map.map[nextPosY, playerPosX] == '^')
                {
                    HealthSystem.TakeDamage("player", 60, ref Player.health);
                }
                else
                {
                    if (Map.map[nextPosY, playerPosX] == '@')
                    {
                        HealthSystem.Heal(40, ref Player.health);
                    }

                    oldPosY = playerPosY;

                    playerPosY = nextPosY;

                    CheckNextMove();

                    PlayerMoved();

                    Console.WriteLine("W");
                }
            }

        }


        public static void KeyA()
        {
            var ey = new Enemy();

            nextPosX = playerPosX - 1;

            lastPosY = playerPosY;
            lastPosX = playerPosX;

            if (playerPosX != 0 && Map.map[playerPosY, nextPosX] != '#' && Map.map[playerPosY, nextPosX] != '~')
            {


                if (Map.map[playerPosY, nextPosX] == '0')
                {
                    HealthSystem.TakeDamage("enemy", 60, ref ey.health);
                }
                else if (Map.map[playerPosY, nextPosX] == '^')
                {
                    HealthSystem.TakeDamage("player", 60, ref Player.health);
                }
                else
                {
                    if (Map.map[playerPosY, nextPosX] == '@')
                    {
                        HealthSystem.Heal(40, ref Player.health);
                    }

                    oldPosX = playerPosX;

                    playerPosX = nextPosX;

                    CheckNextMove();

                    PlayerMoved();

                    Console.WriteLine("A");
                }
            }

        }

        public static void KeyS()
        {
            var ey = new Enemy();

            nextPosY = playerPosY + 1;

            lastPosY = playerPosY;
            lastPosX = playerPosX;

            if (playerPosY != Map.height - 1 && Map.map[nextPosY, playerPosX] != '#' && Map.map[nextPosY, playerPosX] != '~')
            {

                if (Map.map[nextPosY, playerPosX] == '0')
                {
                    HealthSystem.TakeDamage("enemy", 60, ref ey.health);
                }
                else if (Map.map[nextPosY, playerPosX] == '^')
                {
                    HealthSystem.TakeDamage("player", 60, ref Player.health);
                }
                else
                {
                    if (Map.map[nextPosY, playerPosX] == '@')
                    {
                        HealthSystem.Heal(40, ref Player.health);
                    }


                    oldPosY = playerPosY;

                    playerPosY = nextPosY;

                    CheckNextMove();

                    PlayerMoved();

                    Console.WriteLine("S");
                }
            }

        }


        public static void KeyD()
        {
            var ey = new Enemy();

            nextPosX = playerPosX + 1;

            lastPosY = playerPosY;
            lastPosX = playerPosX;

            if (playerPosX != Map.width - 1 && Map.map[playerPosY, nextPosX] != '#' && Map.map[playerPosY, nextPosX] != '~')
            {

                if (Map.map[playerPosY, nextPosX] == '0')
                {
                    HealthSystem.TakeDamage("enemy", 40, ref ey.health);
                }
                else if (Map.map[playerPosY, nextPosX] == '^')
                {
                    HealthSystem.TakeDamage("player", 60, ref Player.health);
                }
                else
                {
                    if (Map.map[playerPosY, nextPosX] == '@')
                    {
                        HealthSystem.Heal(40, ref Player.health);
                    }

                    oldPosX = playerPosX;

                    playerPosX = nextPosX;

                    CheckNextMove();

                    PlayerMoved();

                    Console.WriteLine("D");
                }
            }


        }


        public static void CheckNextMove()
        {
            if (nextPosX == '^' || nextPosY == '^')
            {
                nextPosX = oldPosX;
                nextPosY = oldPosY;
            }
        }


        static void PlayerMoved()
        {
            Map.map[lastPosY, lastPosX] = '`';

            Map.map[playerPosY, playerPosX] = Player.gameChar;

        }





    }




}