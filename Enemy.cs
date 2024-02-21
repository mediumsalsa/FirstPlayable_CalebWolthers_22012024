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

        public int scoreValue;
        public int xpValue;
        public int goldDrop;

        public static int goblinDamage = 20;

        public static char enemyChar;

        public static int health;
        
        public static int enemyPosX { get; set; }
        public static int enemyPosY { get; set; }

        public static bool enemyUp = true;
        public static int enemyHealth = 100;

        public static int enemyNextPosX;
        public static int enemyNextPosY;

        public static int enemyLastPosX;
        public static int enemyLastPosY;


        public Enemy(int posX = 0, int posY = 0, char icon = '0')
        {
            enemyPosX = posX;
            enemyPosY = posY;
            enemyChar = icon;
            Enemy.health = 100;
        }






        public static void SetEnemy(Enemy enemy)
        {
            enemyPosX = enemy.enemyPosX;
            enemyPosY = enemy.enemyPosY;
        }



        public static void MoveEnemy(ref int CenemyPosX, ref int CenemyPosY, ref bool CenemyUp, char enemy)
        {
            if (enemy != '`')
            {
                if (CenemyUp == true)
                {
                    enemyNextPosY = CenemyPosY - 1;

                    enemyLastPosY = CenemyPosY;
                    enemyLastPosX = CenemyPosX;

                    if (CenemyPosY != 0 && Map.map[enemyNextPosY, CenemyPosX] != '#' && Map.map[enemyNextPosY, CenemyPosX] != '~')
                    {
                        if (Map.map[enemyNextPosY, CenemyPosX] == 'P' && enemy != '`')
                        {
                            if (health > 0)
                            {
                                HealthSystem.TakeDamage("player", 20, ref Player.health);
                            }
                        }
                        else
                        {
                            CenemyPosY--;

                            Map.map[enemyLastPosY, enemyLastPosX] = '`';

                            Map.map[CenemyPosY, CenemyPosX] = enemy;

                        }
                    }
                    else { CenemyUp = false; }
                }

                else if (CenemyUp == false)
                {
                    enemyNextPosY = CenemyPosY + 1;

                    enemyLastPosY = CenemyPosY;
                    enemyLastPosX = CenemyPosX;

                    if (CenemyPosY != Map.height - 1 && Map.map[enemyNextPosY, CenemyPosX] != '#' && Map.map[enemyNextPosY, CenemyPosX] != '~')
                    {
                        if (Map.map[enemyNextPosY, CenemyPosX] == 'P' && enemy != '`')
                        {
                            if (health >= 0)
                            {
                                HealthSystem.TakeDamage("player", 20, ref Player.health);
                            }
                        }
                        else
                        {

                            CenemyPosY++;

                            Map.map[enemyLastPosY, enemyLastPosX] = '`';

                            Map.map[CenemyPosY, CenemyPosX] = enemy;

                        }
                    }
                    else { CenemyUp = true; }
                }
            }
        }


    }
}
