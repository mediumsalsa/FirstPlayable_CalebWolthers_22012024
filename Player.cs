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
        public int attack;
        public int posX;
        public int posY;
        public int nextPosX;
        public int nextPosY;
        public int lastPosX;
        public int lastPosY;
        private Map map;
        private EnemyManager enemyManager;
        public HealthSystem healthSystem;
        private UI ui;


        public void SetStuff(Map map, EnemyManager enemyManager, UI ui)
        {
            this.map = map;
            this.enemyManager = enemyManager;
            this.ui = ui;
            health = 100;
            healthSystem = new HealthSystem(health);
            moves = 0;
            shield = 0;
            attack = 100;
            playerChar = 'P';
            posX = 4;
            posY = 20;
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

            nextPosX = posX + nextX; 
            nextPosY = posY + nextY;

            lastPosY = posY;
            lastPosX = posX;

            CheckNextMove();

            posY = nextPosY;
            posX = nextPosX;

            //EnemyManager.UpdateEnemies();
        }

        public void Draw()
        {
            map.map[lastPosY, lastPosX] = '`';

            map.map[posY, posX] = playerChar;
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

            if (posX != map.width - 1 && posY != map.height - 1 && posX != 0 && posY != 0)
            {

                if (map.map[posY, nextPosX] == '^' || map.map[nextPosY, posX] == '^')
                {
                    CantMove();
                }
                else if (map.map[posY, nextPosX] == '~' || map.map[nextPosY, posX] == '~')
                {
                    CantMove();
                }
                else if (map.map[posY, nextPosX] == '#' || map.map[nextPosY, posX] == '#')
                {
                    CantMove();
                }

                CheckForEnemies();

            }
        }

        public void CheckForEnemies()
        {
            foreach (var enemy in enemyManager.enemies)
            {
                if ((posY == enemy.posY && nextPosX == enemy.posX) || (nextPosY == enemy.posY && posX == enemy.posX))
                {
                    if (enemy.health > 0)
                    {
                        CantMove();
                        enemy.healthSystem.health = 0;
                        enemy.healthSystem.TakeDamage(attack);
                        enemy.health += enemy.healthSystem.health;
                        Console.SetCursorPosition(0, map.cameraHeight + 22);
                        ui.UpdateHUD(enemy);
                    }
                }
            }
        }



    }
}