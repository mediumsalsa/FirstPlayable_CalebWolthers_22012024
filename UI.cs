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




        public static void LoadStartingScreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{================================================================}");
            Console.WriteLine("{================================================================}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("");
            Console.WriteLine("  ##     #     ##    #      ##      ##  ##        ####   ###### ");     
            Console.WriteLine("   ##   ###   ##    # #     ##      ####         ##  ##  ##     ");       
            Console.WriteLine("    ## ## ## ##    #####    ##      ##           ##  ##  ####   ");       
            Console.WriteLine("     ###   ###    ##   ##   ##      ####         ##  ##  ##     ");       
            Console.WriteLine("      #     #    ##     ##  ######  ##  ##        ####   ##     ");       
            Console.WriteLine();
            Console.WriteLine("      ##      ######  ######  ######  ###   ##  ####    ##### ");
            Console.WriteLine("      ##      ##      ##      ##      ## #  ##  ##  #  ##     ");
            Console.WriteLine("      ##      ####    ##  ##  ####    ## ## ##  ##  #   ####  ");
            Console.WriteLine("      ##      ##      ##   #  ##      ##  # ##  ##  #      ## ");
            Console.WriteLine("      ######  ######  ######  ######  ##   ###  ####   #####  ");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{================================================================}");
            Console.WriteLine("{================================================================}");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" Reach the ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("dragon");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" and destroy him");
            Console.WriteLine();
            Console.WriteLine(" Your attack power increases with every kill.");
            Console.Write(" Defeat as many enemies as you can before reaching the ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("dragon");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" Press any key to continue");

            Console.ReadKey();
            Console.Clear();
        }


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


            Console.SetCursorPosition(0, Map.cameraHeight + 2);
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.SetCursorPosition(0, Map.cameraHeight + 2);


            //Player Stats
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("");
            Console.WriteLine(breaker);
            Console.WriteLine("Player Stats:");           
            Console.WriteLine("");                                              
            Console.WriteLine("Shield: " + Player.shield);                      
            Console.WriteLine("Health: " + Player.health);                      
            Console.WriteLine("Health Status: " + healthStatus);
            Console.WriteLine("Attack Power: " + Player.playerAttack);
            Console.WriteLine("last Item Aquired: " + lastItem);
            Console.WriteLine(breaker);
            Console.WriteLine("");
            ShowEnemyHUD(ey);

            //Controls 
            Console.ForegroundColor = ConsoleColor.Red;
            int controlsStartPosY = 0;
            int controlsStartPosX = Map.cameraWidth + 5;
            Console.SetCursorPosition(controlsStartPosX, controlsStartPosY);
            Console.WriteLine(breaker);
            Console.SetCursorPosition(controlsStartPosX, controlsStartPosY + 1);
            Console.WriteLine("Controls:");
            Console.SetCursorPosition(controlsStartPosX, controlsStartPosY + 2);
            Console.WriteLine("W - Move Up");
            Console.SetCursorPosition(controlsStartPosX, controlsStartPosY + 3);
            Console.WriteLine("S - Move Down");
            Console.SetCursorPosition(controlsStartPosX, controlsStartPosY + 4);
            Console.WriteLine("A - Move Left");
            Console.SetCursorPosition(controlsStartPosX, controlsStartPosY + 5);
            Console.WriteLine("D - Move Right");
            Console.SetCursorPosition(controlsStartPosX, controlsStartPosY + 6);
            Console.WriteLine("R - Restart Game");
            Console.SetCursorPosition(controlsStartPosX, controlsStartPosY + 7);
            Console.WriteLine("ESCAPE - Quit Game");
            Console.SetCursorPosition(controlsStartPosX, controlsStartPosY + 8);
            Console.WriteLine(breaker);

            //Legend
            Console.ForegroundColor = ConsoleColor.White;
            int legendStartPosY = Map.cameraHeight + 3;
            int legendStartPosX = controlsStartPosX;
            Console.SetCursorPosition(legendStartPosX, legendStartPosY);
            Console.WriteLine(breaker);
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 1);
            Console.WriteLine("Legend:");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 2);
            Console.WriteLine(Player.playerChar + " - Player");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 3);
            Console.WriteLine("^ - Mountains");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 4);
            Console.WriteLine("# - Trees");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 5);
            Console.WriteLine("~ - Water");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 6);
            Console.WriteLine(ItemHealth.itemChar + " - Health Potion");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 7);
            Console.WriteLine(ItemInvincible.itemChar + " - Invincibility");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 8);
            Console.WriteLine(ItemShield.itemChar + " - Shield");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 9);
            Console.WriteLine("G - Goblin");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 10);
            Console.WriteLine("O - Orc");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 11);
            Console.WriteLine("{ - Minotaur");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 12);
            Console.WriteLine("D - Dragon");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 14);
            Console.WriteLine(breaker);


            Console.CursorVisible = !true;
        }

        public static void ShowEnemyHUD(Enemy enemy)
        {

            if (enemy != null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
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
