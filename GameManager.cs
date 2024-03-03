using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class GameManager
    {




        public static void StartGame()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            Console.SetCursorPosition(0, 0);

            Console.CursorVisible = !true;

            Player.SetPlayer();

            Map.StartMap();

            EnemyManager.StartEnemies();

            ItemManager.StartItems();

            Player.GetInput();

            Console.Clear();
        }









    }
}
