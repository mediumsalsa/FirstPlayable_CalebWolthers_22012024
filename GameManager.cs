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


        public static void GameplayLoop()
        {
            InitObjects();

            while (true) 
            {
                Update();
            }
        }



        public static void InitObjects()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            Console.SetCursorPosition(0, 0);

            Console.CursorVisible = !true;

            Player.SetPlayer();

            Map.StartMap();

            UI.LoadStartingScreen();

            UI.StartHUD();

            EnemyManager.StartEnemies();

            ItemManager.StartItems();

        }

        public static void Update() 
        {
            Player.GetInput();
        }









    }
}
