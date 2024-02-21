using System;
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
        static Enemy goblin = new Enemy();
        static Item sword = new Item();


        static void Main(string[] args)
        {

            Console.WriteLine("Start Game");
            Console.WriteLine("");

            slime.enemyPosX = 12;
            slime.enemyPosY = 12;
            slime.enemyChar = '0';
            slime.health = 100;
            slime.enemyUp = true;

            goblin.enemyPosX = 5;
            goblin.enemyPosY = 5;
            goblin.enemyChar = '3';
            goblin.health = 100;
            slime.enemyUp = false;

            StartGame();

            Console.WriteLine("");
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey(true);

        }


        public static void GetInput()
        {
            var exit = false;

            ConsoleKeyInfo keyInfo;

            do
            {

                keyInfo = Console.ReadKey(true);

                Console.WriteLine();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        Player.KeyW();

                        break;

                    case ConsoleKey.A:
                        Player.KeyA();

                        break;

                    case ConsoleKey.S:
                        Player.KeyS();

                        break;

                    case ConsoleKey.D:
                        Player.KeyD();

                        break;

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;

                    case ConsoleKey.R:
                        Program.StartGame();
                        break;

                    default:
                        //ExitProgram();
                        break;

                }
                Enemy.MoveEnemy(ref slime.enemyPosX, ref slime.enemyPosY, ref slime.enemyUp, slime.enemyChar);
                Enemy.MoveEnemy(ref goblin.enemyPosX, ref goblin.enemyPosY, ref goblin.enemyUp, goblin.enemyChar);

            }


            while (exit == false);

        }




        public static void StartGame()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 0);

            Console.CursorVisible = !true;


            Console.WriteLine("");

            Player.SetPlayer();
            Enemy.SetEnemy(slime.enemyPosX, slime.enemyPosY, slime.enemyChar, slime.health, slime.enemyUp);
            Enemy.SetEnemy(goblin.enemyPosX, goblin.enemyPosY, goblin.enemyChar, goblin.health, goblin.enemyUp);
            Map.StartMap();

            Map.map[slime.enemyPosX, slime.enemyPosY] = slime.enemyChar;
            Map.map[goblin.enemyPosX, goblin.enemyPosY] = goblin.enemyChar;

            GetInput();

            Console.WriteLine("");
        }


    }
}