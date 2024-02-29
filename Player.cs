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

        public static int nextPosX;
        public static int nextPosY;

        public static int lastPosX;
        public static int lastPosY;

        //Sets the player up for the start of the game
        public static void SetPlayer()
        {
            health = 100;

            shield = 0;

            playerAttack = 50;

            gameChar = 'P';

            playerPosX = 4;
            playerPosY = 20;  
        }


        //Gets input
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
                        MovePlayer(0, -1);
                        break;

                    case ConsoleKey.A:
                        MovePlayer(-1, 0);
                        break;

                    case ConsoleKey.S:
                        MovePlayer(0, 1);
                        break;

                    case ConsoleKey.D:
                        MovePlayer(1, 0);
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


        //Moves the player
        public static void MovePlayer(int nextX, int nextY)
        { 
            nextPosX = playerPosX + nextX; 
            nextPosY = playerPosY + nextY;

            lastPosY = playerPosY;
            lastPosX = playerPosX;

            CheckNextMove();

            playerPosY = nextPosY;
            playerPosX = nextPosX;

            Map.map[lastPosY, lastPosX] = '`';

            Map.map[playerPosY, playerPosX] = Player.gameChar;

            GameManager.MoveAllEnemies();
        }



        //Makes sure the player doesnt move
        public static void CantMove()
        {
            nextPosY = lastPosY;
            nextPosX = lastPosX;
        }


        //Checks the tile in front of the player to see whats there
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


        //attacks the enemy
        public static void PlayerHitEnemy(Enemy ey)
        {
            if ((playerPosY == ey.enemyPosY && nextPosX == ey.enemyPosX) || (nextPosY == ey.enemyPosY && playerPosX == ey.enemyPosX))
            {
                if (ey.health > 0)
                {
                    CantMove();

                    HealthSystem.TakeDamage("enemy", Player.playerAttack, ref ey.health, ey);

                    Map.UpdateHUD(ey);
                }
            }
        }
        //Map.map[playerPosY, nextPosX] == Map.map[ey.enemyPosY, ey.enemyPosX] || Map.map[nextPosY, playerPosX] == Map.map[ey.enemyPosY, ey.enemyPosX]




    }
}