﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Reflection.Emit;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Map
    {

        static string[] mapFile;

        public static char[,] map;

        public static string breaker = "------------------------";

        public static string healthStatus;

        public static int[] up = {-1, 0};
        public static int[] left = {0, -1};
        public static int[] down = {1, 0};
        public static int[] right = {0, 1};

        static int currentRow = 0;
        static int currentCol = 0;

        public static int width;
        public static int height;


        public static void StartMap()
        {

            mapFile = File.ReadAllLines(@"Map1.txt");

            map = new char[mapFile.Length, mapFile[0].Length];

            width = map.GetLength(1);
            height = map.GetLength(0);

            MakeMap();

            map[Player.playerPosX, Player.playerPosY] = Player.gameChar;

            DisplayMap();
        }


        public static void AddDirection(int dir)
        { 
            
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


        public static void DisplayMap()
        {
            Console.SetCursorPosition(0, 0);

            Console.CursorVisible = !true;
            //Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("+");
            for (int i = 0; i < width; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("+");

            while (currentCol < width)
            {
                if (currentCol == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("|");
                }

                DrawTile();
                currentCol++;

                if (currentCol >= width)
                {
                    currentRow++;
                    if (currentRow < height)
                    {
                        currentCol = 0;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("|");
                        Console.WriteLine();
                    }
                    else
                    {
                        currentCol = width + 2;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("|");
                    }
                }

            }
            Console.WriteLine("");
            Console.Write("+");
            for (int i = 0; i < width; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("+");

            currentCol = 0;
            currentRow = 0;

            Console.CursorVisible = !true;

            ShowHUD();
        }


        static void DrawTile()
        {
            if (map[currentRow, currentCol] == '`')
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (map[currentRow, currentCol] == '~')
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (map[currentRow, currentCol] == 'P')
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else if (map[currentRow, currentCol] == '#')
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else if (map[currentRow, currentCol] == '0')
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else if (map[currentRow, currentCol] == 'G')
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else if (map[currentRow, currentCol] == 'G')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            else if (map[currentRow, currentCol] == 'O')
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else if (map[currentRow, currentCol] == '^')
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            else if (map[currentRow, currentCol] == '@')
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }

            Console.Write(map[currentRow, currentCol]);
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
            Console.WriteLine("                                                ");
            Console.WriteLine("                                                ");
            Console.WriteLine("                                                ");
            Console.WriteLine("                                                ");
            Console.WriteLine("                                                ");
            Console.WriteLine("                                                ");
            Console.WriteLine("                                                ");
            Console.WriteLine("                                                ");
            Console.WriteLine("                                                ");
            Console.SetCursorPosition(0, height + 2
                );



            Console.WriteLine("");
            Console.WriteLine(breaker);
            Console.WriteLine("Health: " + Player.health);
            Console.WriteLine("Health Status: " + healthStatus);
            Console.WriteLine(breaker);
            Console.WriteLine("");

            Console.CursorVisible = !true;
        }





    }
}
