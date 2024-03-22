using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class UI
    {

        public static string breaker = "------------------------";

        public static string healthStatus;

        public static string lastItem;

        public static Enemy ey; 


        public static void StartHUD()
        { 
            ey = new Enemy();
        }


        public static void UpdateHUD(Enemy enemy)
        {
            ey = enemy;
        }


        public static void ShowHUD()
        {
            if (Player.health >= 100)
            { healthStatus = "Perfect Health"; }

            else if (Player.health < 99 && Player.health >= 90)
            { healthStatus = "Healthy"; }

            else if (Player.health < 89 && Player.health >= 75)
            { healthStatus = "Hurt"; }

            else if (Player.health < 74 && Player.health >= 50)
            { healthStatus = "Badly Hurt"; }

            else if (Player.health < 49 && Player.health >= 20)
            { healthStatus = "Danger"; }

            else if (Player.health < 19 && Player.health > 0)
            { healthStatus = "ALMOST DEAD"; }

            else { healthStatus = "Dead"; }


            Console.SetCursorPosition(0, Map.height + 2);
            Console.WriteLine("                                                        ");
            Console.WriteLine("                                                        ");
            Console.WriteLine("                                                        ");
            Console.WriteLine("                                                        ");
            Console.WriteLine("                                                        ");
            Console.WriteLine("                                                        ");
            Console.WriteLine("                                                        ");
            Console.WriteLine("                                                        ");
            Console.WriteLine("                                                        ");
            Console.WriteLine("                                                        ");
            Console.WriteLine("                                                        ");
            Console.WriteLine("                                                        ");
            Console.WriteLine("                                                        ");
            Console.WriteLine("                                                        ");
            Console.WriteLine("                                                        ");
            Console.WriteLine("                                                        ");
            Console.WriteLine("                                                        ");
            Console.WriteLine("                                                        ");
            Console.WriteLine("                                                        ");
            Console.SetCursorPosition(0, Map.cameraHeight + 2);



            Console.WriteLine("");
            Console.WriteLine(breaker);
            Console.WriteLine("Player Stats");
            Console.WriteLine("");
            Console.WriteLine("Shield: " + Player.shield);
            Console.WriteLine("Health: " + Player.health);
            Console.WriteLine("Health Status: " + healthStatus);
            Console.WriteLine("Attack Power: " + Player.playerAttack);
            Console.WriteLine("last Item Aquired: " + lastItem);

            Console.WriteLine(breaker);
            Console.WriteLine("");
            ShowEnemyHUD(ey);

            Console.CursorVisible = !true;
        }

        public static void ShowEnemyHUD(Enemy enemy)
        {

            if (enemy != null)
            {

                Console.WriteLine(breaker);
                Console.WriteLine("Number of Enemies: " + Enemy.enemyCount);
                Console.WriteLine("");
                Console.WriteLine("Last enemy encountered: " + enemy.enemyName);
                Console.WriteLine("Health: " + enemy.enemyHealth + "/" + enemy.maxHealth);
                Console.WriteLine("Attack power: " + enemy.enemyDamage);
                Console.WriteLine(breaker);
                Console.WriteLine("");

            }
        }

    }
}
