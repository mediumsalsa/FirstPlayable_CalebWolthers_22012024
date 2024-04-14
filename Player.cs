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
        public char playerChar;
        public int moves;
        public int health;
        public int shield;
        public int playerAttack;
        public int playerPosX;
        public int playerPosY;
        public int nextPosX;
        public int nextPosY;
        public int lastPosX;
        public int lastPosY;
        private Map map;
        //Sets the player up for the start of the game


        public void SetPlayer()
        {
            moves = 0;
            health = 100;
            shield = 0;
            playerAttack = 50;
            playerChar = 'P';
            playerPosX = 4;
            playerPosY = 20;  
        }

        public void SetMap(Map map)
        {
            this.map = map;
        }

        //Gets input
        public void GetInput()
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
                        Move(0, -1);
                        break;

                    case ConsoleKey.A:
                        Move(-1, 0);
                        break;

                    case ConsoleKey.S:
                        Move(0, 1);
                        break;

                    case ConsoleKey.D:
                        Move(1, 0);
                        break;

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;

                    case ConsoleKey.R:

                        break;

                    default:

                        break;

                }
      
            }


            while (exit == false);

        }

        public void Update(ConsoleKeyInfo input)
        {
            if (input.Key == ConsoleKey.W)
            {
                Move(0, -1);
            }
            else if (input.Key == ConsoleKey.A)
            {
                Move(-1, 0);
            }
            else if (input.Key == ConsoleKey.S)
            {
                Move(0, 1);
            }
            else if (input.Key == ConsoleKey.D)
            {
                Move(1, 0);
            }
        }


        //Moves the player
        public void Move(int nextX, int nextY)
        {
            moves++;

            nextPosX = playerPosX + nextX; 
            nextPosY = playerPosY + nextY;

            lastPosY = playerPosY;
            lastPosX = playerPosX;

            CheckNextMove();

            playerPosY = nextPosY;
            playerPosX = nextPosX;

            //EnemyManager.UpdateEnemies();
        }

        public void Draw()
        {
            map.map[lastPosY, lastPosX] = '`';

            map.map[playerPosY, playerPosX] = playerChar;

            map.DisplayMap();
        }



        //Makes sure the player doesnt move
        public void CantMove()
        {
            nextPosY = lastPosY;
            nextPosX = lastPosX;
        }


        //Checks the tile in front of the player to see whats there
        public void CheckNextMove()
        {

            if (playerPosX != map.width - 1 && playerPosY != map.height - 1 && playerPosX != 0 && playerPosY != 0)
            {

                if (map.map[playerPosY, nextPosX] == '^' || map.map[nextPosY, playerPosX] == '^')
                {
                    CantMove();
                }
                else if (map.map[playerPosY, nextPosX] == '~' || map.map[nextPosY, playerPosX] == '~')
                {
                    CantMove();
                }
                else if (map.map[playerPosY, nextPosX] == '#' || map.map[nextPosY, playerPosX] == '#')
                {
                    CantMove();
                }
                /*
                else if (map.map[playerPosY, nextPosX] == '@' || map.map[nextPosY, playerPosX] == '@')
                {
                    ItemHealth.HealPlayer();
                }
                else if (map.map[playerPosY, nextPosX] == '$' || map.map[nextPosY, playerPosX] == '$')
                {
                    ItemShield.GainShield();
                }
                else if (map.map[playerPosY, nextPosX] == '!' || map.map[nextPosY, playerPosX] == '!')
                {
                    ItemInvincible.Invincibility();
                }*/


                //EnemyManager.CheckForAllEnemies();


            }

        }

        //attacks the enemy
        /*public void PlayerHitEnemy(Enemy ey)
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
        }*/


    }
}