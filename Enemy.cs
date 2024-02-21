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

        public char enemyChar;

        public int health;

        public int enemyPosX;
        public int enemyPosY;

        public string enemyName;

        public bool enemyUp = true;
        public static int enemyHealth = 100;

        public static int enemyNextPosX;
        public static int enemyNextPosY;

        public static int enemyLastPosX;
        public static int enemyLastPosY;




        public static void SetEnemy(string name, int posX, int posY, char icon, int health, bool dir)
        {
            var ey = new Enemy();
            ey.enemyName = name;
            ey.enemyUp = dir;
            ey.enemyPosX = posX;
            ey.enemyPosY = posY;
            ey.enemyChar = icon;
            ey.health = health;

        }



        public static void MoveEnemyVert(ref int CenemyPosX, ref int CenemyPosY, ref bool CenemyUp, char enemyIcon, Enemy enemy)
        {
            if (enemyIcon != '`')
            {
                if (CenemyUp == true)
                {
                    enemyNextPosY = CenemyPosY - 1;

                    enemyLastPosY = CenemyPosY;
                    enemyLastPosX = CenemyPosX;

                    if (CenemyPosY != 0 && Map.map[enemyNextPosY, CenemyPosX] != '#' && Map.map[enemyNextPosY, CenemyPosX] != '~')
                    {
                        if (Map.map[enemyNextPosY, CenemyPosX] == 'P' && enemyIcon != '`')
                        {
                            if (enemy.health > 0)
                            {
                                HealthSystem.TakeDamage("player", 20, ref Player.health, null);
                            }
                        }
                        else
                        {
                            CenemyPosY--;

                            Map.map[enemyLastPosY, enemyLastPosX] = '`';

                            Map.map[CenemyPosY, CenemyPosX] = enemyIcon;

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
                        if (Map.map[enemyNextPosY, CenemyPosX] == 'P' && enemyIcon != '`')
                        {
                            if (enemy.health >= 0)
                            {
                                HealthSystem.TakeDamage("player", 20, ref Player.health, null);
                            }
                        }
                        else
                        {

                            CenemyPosY++;

                            Map.map[enemyLastPosY, enemyLastPosX] = '`';

                            Map.map[CenemyPosY, CenemyPosX] = enemyIcon;

                        }
                    }
                    else { CenemyUp = true; }
                }
            }

            Map.DisplayMap();
        }

        public static void MoveEnemyRandom(ref int CenemyPosX, ref int CenemyPosY, char enemyIcon, Enemy enemy)
        {

            if (enemyIcon != '`')
            {


                var rd = new Random();
                int dir = rd.Next(1, 4);


            }


            Map.DisplayMap();
        }





    }
}
