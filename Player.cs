using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Player : Entity
    {


        public static int health = 100;
        public static int shield = 0;

        public static int playerAttack = 50;

        public static int playerPosX;
        public static int playerPosY;

        public static string dir;

        public static int nextPosX;
        public static int nextPosY;

        public static int lastPosX;
        public static int lastPosY;

        public static int oldPosX;
        public static int oldPosY;

        public static void SetPlayer()
        {
            Player.health = 100;

            Player.shield = 0;

            Player.playerAttack = 50;

            Player.gameChar = 'P';

            playerPosX = 4;
            playerPosY = 20;

            
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

                    case ConsoleKey.R:
                        GameManager.StartGame();
                        break;

                    default:

                        break;

                }



            }


            while (exit == false);

        }




        public static void KeyW()
        {
            dir = "up";

            nextPosY = playerPosY - 1;

            lastPosY = playerPosY;
            lastPosX = playerPosX;

            if (playerPosY != 0 )
            {

                oldPosY = playerPosY;

                CheckNextMove();

                playerPosY = nextPosY;

                PlayerMoved();
            }

        }


        public static void KeyA()
        {
            dir = "left";

            nextPosX = playerPosX - 1;

            lastPosY = playerPosY;
            lastPosX = playerPosX;

            if (playerPosX != 0 )
            {

                oldPosX = playerPosX;

                CheckNextMove();

                playerPosX = nextPosX;

                PlayerMoved();
            }

        }

        public static void KeyS()
        {
            dir = "down";

            nextPosY = playerPosY + 1;

            lastPosY = playerPosY;
            lastPosX = playerPosX;

            if (playerPosY != Map.height - 1)
            {

                oldPosY = playerPosY;

                CheckNextMove();

                playerPosY = nextPosY;

                PlayerMoved();
            }
        }


        public static void KeyD()
        {
            dir = "right";

            nextPosX = playerPosX + 1;

            lastPosY = playerPosY;
            lastPosX = playerPosX;

            if (playerPosX != Map.width - 1)
            {
                oldPosX = playerPosX;

                CheckNextMove();

                playerPosX = nextPosX;

                PlayerMoved();
            }


        }

        public static void CantMove()
        {
            if (dir == "up" || dir == "down")
            {
                nextPosY = oldPosY;
            }
            else if (dir == "left" || dir == "right")
            {
                nextPosX = oldPosX;
            }
        }




        public static void CheckNextMove()
        {
            var ey = new Enemy();

            if (playerPosX != Map.width - 1 && playerPosY != Map.height - 1 && playerPosX != 0 && playerPosY != 0)
            {

                if (Map.map[playerPosY, nextPosX] == '^' || Map.map[nextPosY, playerPosX] == '^')
                {
                    CantMove();
                    HealthSystem.TakeDamage("player", 60, ref health, null);
                }
                else if (Map.map[playerPosY, nextPosX] == '~' || Map.map[nextPosY, playerPosX] == '~')
                {
                    CantMove();
                }
                else if (Map.map[playerPosY, nextPosX] == '#' || Map.map[nextPosY, playerPosX] == '#')
                {
                    CantMove();
                }
                else if (Map.map[playerPosY, nextPosX] == '@' || Map.map[nextPosY, playerPosX] == '@')
                {
                    Map.lastItem = "Health Potion(+60 health)";
                    HealthSystem.Heal(40, ref health);
                }
                else if (Map.map[playerPosY, nextPosX] == '7' || Map.map[nextPosY, playerPosX] == '7')
                {
                    Map.lastItem = "Golems Greatsword(+50 attack)";
                    playerAttack += 50;
                }
                if (Map.map[playerPosY, nextPosX] == '*' || Map.map[nextPosY, playerPosX] == '*')
                {
                    Map.lastItem = "Helmet of immortality";
                    HealthSystem.Heal(200, ref shield);
                }


                GameManager.CheckForAllEnemies();


            }

        }





        public static void PlayerMoved()
        {
            Map.map[lastPosY, lastPosX] = '`';

            Map.map[playerPosY, playerPosX] = Player.gameChar;

            GameManager.MoveAllEnemies();
        }





    }




}