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
        static Enemy slime1 = new Enemy();
        static Item sword = new Item();


        static void Main(string[] args)
        {

            Console.WriteLine("Start Game");
            Console.WriteLine("");

            //player.gameChar = 'P';
            player.position.x = 10;
            player.position.y = 10;

            slime1.position.x = 10;
            slime1.position.y = 10;

            sword.position.x = 5;
            sword.position.y = 5;



            Console.WriteLine("Player x position is " + player.position.x);
            Console.WriteLine("Player y position is " + player.position.y);


            StartGame();

            Console.WriteLine("");
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey(true);

        }


        static void StartGame()
        {
            Console.WriteLine("");

            Player.SetPlayer();
            Map.StartMap();
            Player.GetInput();

            Console.WriteLine("");
        }


    }
}
