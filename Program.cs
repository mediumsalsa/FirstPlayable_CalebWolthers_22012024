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
    internal class Program
    {

        static Player player = new Player();
        static Enemy slime = new Enemy();
        static Item sword = new Item();


        static void Main(string[] args)
        {

            Console.WriteLine("Start Game");
            Console.WriteLine("");

            //player.gameChar = 'P';


            slime.position.x = 10;
            slime.position.y = 10;


            



            Console.WriteLine("Player x position is " + player.position.x);
            Console.WriteLine("Player y position is " + player.position.y);


            StartGame();

            Console.WriteLine("");
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey(true);

        }


        public static void StartGame()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 0);

            Console.CursorVisible = !true;


            Console.WriteLine("");

            Player.SetPlayer();
            Enemy.SetEnemy();
            Map.StartMap();
            Player.GetInput();

            Console.WriteLine("");
        }


    }
}