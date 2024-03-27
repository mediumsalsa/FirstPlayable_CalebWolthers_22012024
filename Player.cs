using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Player
    {
        public static char playerChar;
        public static int moves;

        public static int health;
        public static int shield;

        public static int playerAttack;

        public static int playerPosX;
        public static int playerPosY;

        public static int nextPosX;
        public static int nextPosY;

        public static int lastPosX;
        public static int lastPosY;

        //Sets the player up for the start of the game
        public static void SetPlayer()
        {
            moves = 0;

            health = Settings.playerHealth;

            shield = Settings.playerShield;

            playerAttack = Settings.playerAttack;

            playerChar = Settings.playerChar;

            playerPosX = Settings.playerStartPosX;
            playerPosY = Settings.playerStartPosY;  
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
                        GameManager.GameplayLoop();
                        Map.DisplayMap();
                        Map.DisplayMap();
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

            moves++;

            nextPosX = playerPosX + nextX; 
            nextPosY = playerPosY + nextY;

            lastPosY = playerPosY;
            lastPosX = playerPosX;

            CheckNextMove();

            playerPosY = nextPosY;
            playerPosX = nextPosX;

            Map.map[lastPosY, lastPosX] = '`';

            Map.map[playerPosY, playerPosX] = playerChar;

            EnemyManager.MoveAllEnemies();
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
                    ItemHealth.HealPlayer();
                }
                else if (Map.map[playerPosY, nextPosX] == '$' || Map.map[nextPosY, playerPosX] == '$')
                {
                    ItemShield.GainShield();
                }
                else if (Map.map[playerPosY, nextPosX] == '!' || Map.map[nextPosY, playerPosX] == '!')
                {
                    ItemInvincible.Invincibility();
                }


                EnemyManager.CheckForAllEnemies();


            }

        }

        //attacks the enemy
        public static void PlayerHitEnemy(Enemy ey)
        {
            if ((playerPosY == ey.enemyPosY && nextPosX == ey.enemyPosX) || (nextPosY == ey.enemyPosY && playerPosX == ey.enemyPosX))
            {
                if (ey.enemyHealth > 0)
                {
                    CantMove();

                    HealthSystem.TakeDamage("enemy", Player.playerAttack, ref ey.enemyHealth, ey);

                    UI.UpdateHUD(ey);
                }
            }
        }


    }
}