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


        public static void GetInput()
        {


            var exit = false;

            ConsoleKeyInfo keyInfo;

            do
            {

                keyInfo = Console.ReadKey(true);

                Console.WriteLine();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        KeyW();
                        break;

                    case ConsoleKey.A:
                        KeyA();
                        break;

                    case ConsoleKey.S:
                        KeyS();
                        break;

                    case ConsoleKey.D:
                        KeyD();
                        break;

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;

                    default:
                        //ExitProgram();
                        break;

                }

            }

            while (exit == false);

        }

        static void KeyW()
        {
            nextPosY = playerPosY - 1;

            lastPosY = playerPosY;
            lastPosX = playerPosX;

            if (playerPosY != 0 && Map.map[nextPosY, playerPosX] != '#' && Map.map[nextPosY, playerPosX] != '~')
            { 

                if (Map.map[nextPosY, playerPosX] == '0')
                {
                    HealthSystem.TakeDamage("enemy", 60, ref Enemy.health);
                    HealthSystem.TakeDamage("player", 20, ref Player.health);
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

            Map.DisplayMap();

        }


        static void KeyA()
        {
            nextPosX = playerPosX - 1;

            lastPosY = playerPosY;
            lastPosX = playerPosX;

            if (playerPosX != 0 && Map.map[playerPosY, nextPosX] != '#' && Map.map[playerPosY, nextPosX] != '~')
            {


                if (Map.map[playerPosY, nextPosX] == '0')
                {
                    HealthSystem.TakeDamage("enemy", 60, ref Enemy.health);
                    HealthSystem.TakeDamage("player", 20, ref Player.health);
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

            Map.DisplayMap();

        }

        static void KeyS()
        {
            nextPosY = playerPosY + 1;

            lastPosY = playerPosY;
            lastPosX = playerPosX;

            if (playerPosY != Map.height - 1 && Map.map[nextPosY, playerPosX] != '#' && Map.map[nextPosY, playerPosX] != '~')
            {

                if (Map.map[nextPosY, playerPosX] == '0')
                {
                    HealthSystem.TakeDamage("enemy", 60, ref Enemy.health);
                    HealthSystem.TakeDamage("player", 20, ref Player.health);
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

            Map.DisplayMap();

        }


        static void KeyD()
        {
            nextPosX = playerPosX + 1;

            lastPosY = playerPosY;
            lastPosX = playerPosX;

            if (playerPosX != Map.width - 1 && Map.map[playerPosY, nextPosX] != '#' && Map.map[playerPosY, nextPosX] != '~')
            {

                if (Map.map[playerPosY, nextPosX] == '0')
                {
                    HealthSystem.TakeDamage("enemy", 40, ref Enemy.health);
                    HealthSystem.TakeDamage("player", 20, ref Player.health);
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

            Map.DisplayMap();

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

            Enemy.MoveEnemy(ref Enemy.enemyPosX, ref Enemy.enemyPosY, ref Enemy.enemyUp, Enemy.enemyChar);

        }





    }




}