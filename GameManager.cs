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

        //Enemy Holding zone
        static Enemy goblin = new Enemy();

        static Enemy minotaur = new Enemy();

        static Enemy dragon = new Enemy();

        static EnemyOrc[] orcs = new EnemyOrc[25];


        public static void StartGame()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            Console.Clear();

            Console.SetCursorPosition(0, 0);

            Console.CursorVisible = !true;

            Player.SetPlayer();

            Map.StartMap();

            //Give setting in order:
            //Instance, Name, X Position, Y Position, Icon Char, Health, Damage, Current Direction(Unless enemy moves randomly)
            Enemy.SetEnemy(goblin, "Goblin", 5, 15, 'G', 150, 20, "down");

            Enemy.SetEnemy(minotaur, "Purple Minotaur", 40, 9, '}', 500, 30, "right");

            Enemy.SetEnemy(dragon, "Kinda Mighty Dragon", 32, 15, 'D', 1000, 40, null);

            for (int i = 0; i < 25; i++)
            {
                orcs[i] = new EnemyOrc();
                RandomlyPlaceEnemyOrc(orcs[i], 'O', 200, 36);
            }

            Player.GetInput();
        }


        //Places the orcs randomly on the map
        private static void RandomlyPlaceEnemyOrc(EnemyOrc orc, char icon, int health, int damage)
        {
            Random random = new Random();

            while (true)
            {
                int x = random.Next(2, Map.width - 2); 
                int y = random.Next(2, Map.height - 2); 

                if (Map.map[y, x] == '`')
                {
                    EnemyOrc.SetEnemy(orc, "orc", x, y, icon, health, damage, null);
                    break;
                }
            }
        }


        public static void MoveAllEnemies()
        {
            Enemy.MoveEnemyVert(goblin);       
            Enemy.MoveEnemySquare(minotaur);
            Enemy.MoveEnemyRandom(dragon);

            foreach (var orc in orcs)
            {
                EnemyOrc.MoveEnemyRandom(orc);
            }

            Map.DisplayMap();
        }

        public static void CheckForAllEnemies()
        {
            Player.PlayerHitEnemy(goblin);
            Player.PlayerHitEnemy(minotaur);
            Player.PlayerHitEnemy(dragon);

            foreach (var orc in orcs)
            {
                Player.PlayerHitEnemy(orc);
            }
        }





    }
}
