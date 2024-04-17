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
        public static EnemyManager enemyManager;
        public static UI ui;
        public static bool gameOver;



        public void Play()
        {
            //Init
            player = new Player();
            map = new Map(player);
            enemyManager = new EnemyManager(player, map);
            gameOver = false;
            map.StartMap();
            ui = new UI(player, map, enemyManager);
            ui.LoadStartingScreen();
            player.SetStuff(map, enemyManager, ui);
            map.DisplayMap();

            enemyManager.PlaceGoblins(5);
            enemyManager.PlaceOrcs(25);


            while (gameOver == false)
            {
                if (player.healthSystem.health <= 0)
                {
                    gameOver = true;
                }

                GetInput();

                //Update
                player.Update(input);
                enemyManager.UpdateEnemies();

                //Draw
                player.Draw();
                enemyManager.DrawEnemies();
                map.DisplayMap();
                ui.Draw();
            }
            if (gameOver == true)
            {
                Console.Clear();
                Console.WriteLine("Game Over, try again");
            }

        }

        public void GetInput()
        {
            input = Console.ReadKey(true);
        }

        private ConsoleKeyInfo input;
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