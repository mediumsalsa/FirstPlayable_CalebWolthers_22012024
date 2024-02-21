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

        public int enemyDamage;

        public int enemyPosX;
        public int enemyPosY;

        public string enemyName;

        public bool enemyUp = true;
        public static int enemyHealth = 100;

        public static int enemyNextPosX;
        public static int enemyNextPosY;

        public static int enemyLastPosX;
        public static int enemyLastPosY;

        public static Enemy theEnemy = new Enemy();




        public static void SetEnemy(string name, int posX, int posY, char icon, int health, bool dir, int dmg)
        {
            var ey = new Enemy();
            ey.enemyName = name;
            ey.enemyUp = dir;
            ey.enemyPosX = posX;
            ey.enemyPosY = posY;
            ey.enemyChar = icon;
            ey.health = health;
            ey.enemyDamage = dmg;
            Map.map[ey.enemyPosY, ey.enemyPosX] = ey.enemyChar;


        }

        public static void UpdateEnemy(Enemy ey)
        {
            SetEnemy(ey.enemyName, ey.enemyPosX, ey.enemyPosY, ey.enemyChar, ey.health, ey.enemyUp, ey.enemyDamage);
        }


        /*public static void MoveEnemyVert(ref int CenemyPosX, ref int CenemyPosY, ref bool CenemyUp, char enemyIcon, Enemy enemy)
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
                                HealthSystem.TakeDamage("player", enemy.enemyDamage, ref Player.health, null);
                                Map.UpdateHUD(enemy);
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
                                HealthSystem.TakeDamage("player", enemy.enemyDamage, ref Player.health, null);
                                Map.UpdateHUD(enemy);
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


        }*/


        public static void MoveEnemyVert(Enemy ey)
        {
            if (ey.enemyChar != '`')
            {
                if (ey.enemyUp == true)
                {
                    enemyNextPosY = ey.enemyPosY - 1;

                    enemyLastPosY = ey.enemyPosY;
                    enemyLastPosX = ey.enemyPosX;

                    if (ey.enemyPosY != 0 && Map.map[enemyNextPosY, ey.enemyPosX] != '#' && Map.map[enemyNextPosY, ey.enemyPosX] != '~')
                    {
                        if (Map.map[enemyNextPosY, ey.enemyPosX] == 'P' && ey.enemyChar != '`')
                        {
                            if (ey.health > 0)
                            {
                                HealthSystem.TakeDamage("player", ey.enemyDamage, ref Player.health, null);
                                Map.UpdateHUD(ey);
                            }
                        }
                        else
                        {
                            ey.enemyPosY--;

                            Map.map[enemyLastPosY, enemyLastPosX] = '`';

                            Map.map[ey.enemyPosY, ey.enemyPosX] = ey.enemyChar;

                        }
                    }
                    else { ey.enemyUp = false; }
                }

                else if (ey.enemyUp == false)
                {
                    enemyNextPosY = ey.enemyPosY + 1;

                    enemyLastPosY = ey.enemyPosY;
                    enemyLastPosX = ey.enemyPosX;

                    if (ey.enemyPosY != Map.height - 1 && Map.map[enemyNextPosY, ey.enemyPosX] != '#' && Map.map[enemyNextPosY, ey.enemyPosX] != '~')
                    {
                        if (Map.map[enemyNextPosY, ey.enemyPosX] == 'P' && ey.enemyChar != '`')
                        {
                            if (ey.health >= 0)
                            {
                                HealthSystem.TakeDamage("player", ey.enemyDamage, ref Player.health, null);
                                Map.UpdateHUD(ey);
                            }
                        }
                        else
                        {

                            ey.enemyPosY++;

                            Map.map[enemyLastPosY, enemyLastPosX] = '`';

                            Map.map[ey.enemyPosY, ey.enemyPosX] = ey.enemyChar;

                        }
                    }
                    else { ey.enemyUp = true; }
                }
            }


        }





        public static void MoveEnemyRandom(Enemy ey)
        {

            if (ey.enemyChar != '`')
            {


                var rd = new Random();
                int dir = rd.Next(0, 400);


                //Up
                if (dir <= 100)
                {
                    enemyNextPosY = ey.enemyPosY - 1;

                    enemyLastPosY = ey.enemyPosY;
                    enemyLastPosX = ey.enemyPosX;

                    if (Map.map[enemyNextPosY, ey.enemyPosX] == '`')
                    {
                        ey.enemyPosY--;

                        Map.map[enemyLastPosY, enemyLastPosX] = '`';

                        Map.map[ey.enemyPosY, ey.enemyPosX] = ey.enemyChar;
                    }
                    else if (Map.map[enemyNextPosY, ey.enemyPosX] == 'P' && ey.enemyChar != '`')
                    {
                        if (ey.health >= 0)
                        {
                            HealthSystem.TakeDamage("player", ey.enemyDamage, ref Player.health, null);
                            Map.UpdateHUD(ey);
                        }
                    }

                }

                //Left
                else if (dir > 100 && dir <= 200)
                {
                    enemyNextPosX = ey.enemyPosX - 1;

                    enemyLastPosY = ey.enemyPosY;
                    enemyLastPosX = ey.enemyPosX;

                    if (Map.map[ey.enemyPosY, enemyNextPosX] == '`')
                    {
                        ey.enemyPosX--;

                        Map.map[enemyLastPosY, enemyLastPosX] = '`';

                        Map.map[ey.enemyPosY, ey.enemyPosX] = ey.enemyChar;
                    }
                    else if (Map.map[ey.enemyPosY, enemyNextPosX] == 'P' && ey.enemyChar != '`')
                    {
                        if (ey.health >= 0)
                        {
                            HealthSystem.TakeDamage("player", ey.enemyDamage, ref Player.health, null);
                            Map.UpdateHUD(ey);
                        }
                    }

                }

                //Down
                else if (dir > 200 && dir <= 300)
                {
                    enemyNextPosY = ey.enemyPosY + 1;

                    enemyLastPosY = ey.enemyPosY;
                    enemyLastPosX = ey.enemyPosX;

                    if (Map.map[enemyNextPosY, ey.enemyPosX] == '`')
                    {
                        ey.enemyPosY++;

                        Map.map[enemyLastPosY, enemyLastPosX] = '`';

                        Map.map[ey.enemyPosY, ey.enemyPosX] = ey.enemyChar;
                    }
                    else if (Map.map[enemyNextPosY, ey.enemyPosX] == 'P' && ey.enemyChar != '`')
                    {
                        if (ey.health >= 0)
                        {
                            HealthSystem.TakeDamage("player", ey.enemyDamage, ref Player.health, null);
                            Map.UpdateHUD(ey);
                        }
                    }

                }

                //Right
                else if (dir > 300)
                {
                    enemyNextPosX = ey.enemyPosX + 1;

                    enemyLastPosY = ey.enemyPosY;
                    enemyLastPosX = ey.enemyPosX;

                    if (Map.map[ey.enemyPosY, enemyNextPosX] == '`')
                    {
                        ey.enemyPosX++;

                        Map.map[enemyLastPosY, enemyLastPosX] = '`';

                        Map.map[ey.enemyPosY, ey.enemyPosX] = ey.enemyChar;
                    }
                    else if (Map.map[ey.enemyPosY, enemyNextPosX] == 'P' && ey.enemyChar != '`')
                    {
                        if (ey.health >= 0)
                        {
                            HealthSystem.TakeDamage("player", ey.enemyDamage, ref Player.health, null);
                            Map.UpdateHUD(ey);
                        }
                    }
                }





            }


        }


    }
}
