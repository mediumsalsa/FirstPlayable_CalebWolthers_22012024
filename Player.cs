using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Player : Entity
    {


        public int xp;
        public int level;
        public int score;

        public static int startPosX = 10;
        public static int startPosY = 10;

        public static int nextPosX;
        public static int nextPosY;

        public static int lastPosX;
        public static int lastPosY;


        public static void SetPlayer()
        {
            gameChar = 'P';
            
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
                        Console.WriteLine(gameChar);
                        Console.WriteLine("W");
                        break;

                    case ConsoleKey.A:
                        Console.WriteLine("A");
                        break;

                    case ConsoleKey.S:
                        Console.WriteLine("S");
                        break;

                    case ConsoleKey.D:
                        Console.WriteLine("D");
                        break;

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;

                    default:
                        //ExitProgram();
                        break;

                }

            }

            while (exit == false);

        }

    }
}
