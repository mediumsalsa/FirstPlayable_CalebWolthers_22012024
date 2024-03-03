using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class EnemyManager
    {

        //Enemy Holding zone
        static int numberOfGoblins = 5;
        static EnemyGoblin[] goblins = new EnemyGoblin[numberOfGoblins];

        static Enemy minotaur = new Enemy();

        static Enemy dragon = new Enemy();

        static int numberOfOrcs = 25;
        static EnemyOrc[] orcs = new EnemyOrc[numberOfOrcs];



        public static void StartEnemies()
        {
            Enemy.SetEnemy(minotaur, "Purple Minotaur", 40, 9, '}', 500, 30, "up");

            Enemy.SetEnemy(dragon, "Kinda Mighty Dragon", 92, 1, 'D', 20000, 400, null);

            for (int i = 0; i < numberOfGoblins; i++)
            {
                goblins[i] = new EnemyGoblin();
                Enemy.RandomlyPlaceEnemy(goblins[i], "Goblin", 'G', 100, 20, "down", 8, Map.width - 70, 16, Map.height - 2);
            }

            for (int i = 0; i < numberOfOrcs; i++)
            {
                orcs[i] = new EnemyOrc();
                Enemy.RandomlyPlaceEnemy(orcs[i], "Orc", 'O', 200, 40, null, 60, Map.width - 2, 10, Map.height - 2);
            }
        }

        public static void MoveAllEnemies()
        {
            Enemy.MoveEnemySquare(minotaur);
            EnemyOrc.MoveEnemyRandom(dragon);


            foreach (var goblin in goblins)
            {
                EnemyGoblin.MoveEnemyVert(goblin);
            }
            foreach (var orc in orcs)
            {
                EnemyOrc.MoveEnemyRandom(orc);
            }

            Map.DisplayMap();
        }

        public static void CheckForAllEnemies()
        {
            Player.PlayerHitEnemy(minotaur);
            Player.PlayerHitEnemy(dragon);

            foreach (var goblin in goblins)
            {
                Player.PlayerHitEnemy(goblin);
            }
            foreach (var orc in orcs)
            {
                Player.PlayerHitEnemy(orc);
            }
        }






    }
}
