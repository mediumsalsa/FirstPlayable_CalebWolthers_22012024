using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Reflection.Emit;
using System.Security.Policy;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Map
    {

        static string[] mapFile;

        public static char[,] map;

        public static string breaker = "------------------------";

        public static string healthStatus;

        public static string lastItem;


        public static int cameraWidth;
        public static int cameraHeight;

        public static int width;
        public static int height;

        public static Enemy ey = new Enemy();


        public static void StartMap()
        {

            mapFile = File.ReadAllLines(@"Map1.txt");

            map = new char[mapFile.Length, mapFile[0].Length];

            width = map.GetLength(1);
            height = map.GetLength(0);

            cameraWidth = 60;
            cameraHeight = 20;

            MakeMap();

            map[Player.playerPosX, Player.playerPosY] = Player.gameChar;

        }


        public static void MakeMap()
        {
            for (int i = 0; i < mapFile.Length; i++)
            {
                for (int j = 0; j < mapFile[0].Length; j++)
                {
                    map[i, j] = mapFile[i][j];
                }
            }
        }


        //Draws map, and creates a temporary, smaller map that displays based on the players position
        public static void DisplayMap()
        {
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;

            int startX = Math.Max(0, Player.playerPosX - cameraWidth / 2);
            int startY = Math.Max(0, Player.playerPosY - cameraHeight / 2);

            char[,] tempMap = new char[cameraHeight, cameraWidth];

            for (int row = 0; row < cameraHeight; row++)
            {
                for (int col = 0; col < cameraWidth; col++)
                {
                    int mapRow = startY + row;
                    int mapCol = startX + col;

                    if (mapRow < height && mapCol < width)
                    {
                        tempMap[row, col] = map[mapRow, mapCol];
                    }
                    else
                    {
                        tempMap[row, col] = '^';
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("+");
            for (int i = 0; i < cameraWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("+");

            for (int row = 0; row < cameraHeight; row++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("|");

                for (int col = 0; col < cameraWidth; col++)
                {
                    Console.CursorLeft = col + 1;
                    Console.CursorTop = row + 1;

                    DrawTile(tempMap[row, col]);
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("|");
                Console.WriteLine();
            }

            Console.Write("+");
            for (int i = 0; i < cameraWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("+");

            Console.CursorVisible = false;
            ShowHUD();
        }




        static void DrawTile(char tile)
        {
            if (tile == '`')
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (tile == '~')
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (tile == 'P')
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (tile == '#')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (tile == 'G')
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (tile == 'D')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (tile == '!')
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (tile == '$')
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (tile == '§')
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (tile == '*')
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (tile == '}')
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (tile == '7')
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (tile == 'O')
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (tile == '^')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (tile == '@')
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            Console.Write(tile);
        }

        public static void UpdateHUD(Enemy enemy)
        {
            ey = enemy;
        }


        static void ShowHUD()
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


            Console.SetCursorPosition(0, height + 2);
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
            Console.SetCursorPosition(0, height - 2);



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

                Console.WriteLine(Map.breaker);
                Console.WriteLine("Last enemy encountered: " + enemy.enemyName);
                Console.WriteLine("");
                Console.WriteLine("Health: " + enemy.health);
                Console.WriteLine("Attack power: " + enemy.enemyDamage);
                Console.WriteLine(Map.breaker);
                Console.WriteLine("");

            }
        }



    }
}
