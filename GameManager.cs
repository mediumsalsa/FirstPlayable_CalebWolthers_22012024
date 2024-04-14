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

        public static Map map;
        public static Player player;

        public static bool gameOver;
        public static ConsoleKeyInfo input;


        public void Play()
        {
            //Init
            player = new Player();
            map = new Map(player);
            gameOver = false;

            player.SetMap(map);

            player.SetPlayer();

            map.StartMap();

            map.DisplayMap();

            while (gameOver == false)
            {
                GetInput();

                //Update
                player.Update(input);


                //Draw
                player.Draw();

            }
        }

        public void GetInput()
        {
            input = Console.ReadKey(true);
        }


    }

}


/*public static void GameplayLoop()
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

    //EnemyManager.StartEnemies();

    ItemManager.StartItems();

}

public static void Update() 
{
    Player.GetInput();
}









}
}
*/