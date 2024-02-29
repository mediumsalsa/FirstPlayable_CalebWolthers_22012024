using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class GameManager
    {

        //Enemy Holding zone
        static Enemy slime = new Enemy();

        static Enemy rockGolem = new Enemy();

        static Enemy goblin = new Enemy();

        static Enemy bones = new Enemy();

        static Enemy minotaur = new Enemy();

        static Enemy skele = new Enemy();

        static Enemy dragon = new Enemy();

        static Enemy guardian = new Enemy();


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
            Enemy.SetEnemy(slime, "Slime", 5, 7, 'G', 100, 10, "down");

            Enemy.SetEnemy(goblin, "Goblin", 5, 15, 'G', 150, 20, "down");

            Enemy.SetEnemy(bones, "Bone Golem", 16, 16, 'B', 100, 30, null);

            Enemy.SetEnemy(rockGolem, "Rock Golem", 24, 18, 'O', 300, 12, null);

            Enemy.SetEnemy(minotaur, "Purple Minotaur", 40, 9, '}', 500, 30, "right");

            Enemy.SetEnemy(skele, "Skeleton", 6, 4, '$', 300, 40, "up");

            Enemy.SetEnemy(dragon, "Kinda Mighty Dragon", 32, 15, 'D', 1000, 40, null);

            Enemy.SetEnemy(guardian, "Royal Guardian", 6, 12, '!', 350, 150, "up");

            Player.GetInput();

        }



        public static void MoveAllEnemies()
        {
            Enemy.MoveEnemyVert(slime);
            Enemy.MoveEnemyVert(goblin);       
            Enemy.MoveEnemyRandom(bones);
            Enemy.MoveEnemyRandom(rockGolem);
            Enemy.MoveEnemySquare(minotaur);
            Enemy.MoveEnemySquare(skele);
            Enemy.MoveEnemyRandom(dragon);
            Enemy.MoveEnemySquare(guardian);

            Map.DisplayMap();
        }


        public static void CheckForAllEnemies()
        {
            Player.PlayerHitEnemy(slime);
            Player.PlayerHitEnemy(goblin);
            Player.PlayerHitEnemy(bones);
            Player.PlayerHitEnemy(rockGolem);
            Player.PlayerHitEnemy(minotaur);
            Player.PlayerHitEnemy(skele);
            Player.PlayerHitEnemy(dragon);
            Player.PlayerHitEnemy(guardian);
        }





    }
}
