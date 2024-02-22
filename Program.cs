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






        static void Main(string[] args)
        {

            Console.WriteLine("Start Game");
            Console.WriteLine("");

            GameManager.StartGame();

            Console.WriteLine("");
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey(true);

        }






    }
}