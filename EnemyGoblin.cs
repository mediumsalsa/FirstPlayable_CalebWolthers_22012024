﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{

    internal class EnemyGoblin : Enemy
    {
        private int nextPosX;
        private int nextPosY;
        private int lastPosX;
        private int lastPosY;
        private static int goblinCount = 0; 
        private int goblinNumber;
        private Player player;
        private Map map;
        public HealthSystem healthSystem;

        public EnemyGoblin(Map map, Player player) : base(map, player) 
        {
            this.map = map;
            this.player = player;
            health = 150;
            goblinCount++; 
            goblinNumber = goblinCount;
            name = "Goblin" + goblinNumber;
            Char = 'G';
            damage = 20;
            dir = "down";
            minX = 8;
            maxX = map.width - 70;
            minY = 16;
            maxY = map.height - 2;
            healthSystem = new HealthSystem(health);
        }


        public override void Update()
        {
            if (Char != '`')
            {
                //Up
                if (dir == "up")
                {
                    Move(0, -1, "down");
                }
                //Down
                else if (dir == "down")
                {
                    Move(0, 1, "up");
                }
            }
        }

        public override void Draw()
        {
            map.map[lastPosY, lastPosX] = '`';
            map.map[posY, posX] = Char;
        }


        public void Move(int nextX, int nextY, string nextDir)
        {
            nextPosX = posX + nextX;
            nextPosY = posY + nextY;
            bool isWithinBounds = nextPosX >= 0 && nextPosX < map.width && nextPosY >= 0 && nextPosY < map.height;
            lastPosY = posY;
            lastPosX = posX;

            if (isWithinBounds)
            {
                if (health >  0)
                {
                    //Colides with player 
                    if (nextPosX == player.posX && nextPosY == player.posY)
                    {
                        nextPosY = lastPosY;
                        nextPosX = lastPosX;
                    }
                    else if (map.map[nextPosY, nextPosX] == '`')
                    {
                        posX = nextPosX;
                        posY = nextPosY;
                    }
                    else
                    {
                        nextPosY = lastPosY;
                        nextPosX = lastPosX;
                        dir = nextDir; 
                    }
                }
                else 
                {
                    Die();
                }
            }
        }

        public void Die()
        {
            health = 0;
            map.map[posY, posX] = '`';
            posY = 0;
            posX = 0;
            Char = '#';
            map.DisplayMap();
            player.attack += damage;

            Console.SetCursorPosition(0, Map.cameraHeight + 6);
            Console.WriteLine("Goblin dead ");
            //enemyCount--;
        }


    }
}
/*

        public EnemyGoblin()
        {
            enemyName = Settings.goblinName;
            enemyChar = Settings.goblinChar;
            enemyHealth = Settings.goblinHealth;
            enemyDamage = Settings.goblinDamage;
            enemyDir = Settings.goblinDir;

            enemyMinX = Settings.goblinMinX;
            enemyMaxX = Settings.goblinMaxX;
            enemyMinY = Settings.goblinMinY;
            enemyMaxY = Settings.goblinMaxY;
        }


        //Bounces vertically
        public override void Update(Enemy ey)
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



    }
    
} 
*/