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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("");
            Console.WriteLine(" Walk Of Legends");
            Console.WriteLine("");
            Console.Write(" Reach the "); 
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("dragon");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" and destroy him");
            GameManager.StartGame();

        }






    }
}