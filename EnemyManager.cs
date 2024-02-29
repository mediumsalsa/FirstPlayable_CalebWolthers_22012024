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
            //Give setting in order:
            //Instance, Name, X Position, Y Position, Icon Char, Health, Damage, Current Direction(Unless enemy moves randomly)
            //Enemy.SetEnemy(goblin, "Goblin", 5, 15, 'G', 150, 20, "down");


            Enemy.SetEnemy(minotaur, "Purple Minotaur", 40, 9, '}', 500, 30, "up");

            Enemy.SetEnemy(dragon, "Kinda Mighty Dragon", 92, 1, 'D', 1000, 40, null);

            for (int i = 0; i < numberOfGoblins; i++)
            {
                goblins[i] = new EnemyGoblin();
                RandomlyPlaceEnemy(goblins[i], "Goblin", 'G', 100, 20, "down", 8, Map.width - 70, 16, Map.height - 2);
            }

            for (int i = 0; i < numberOfOrcs; i++)
            {
                orcs[i] = new EnemyOrc();
                RandomlyPlaceEnemy(orcs[i], "Orc", 'O', 200, 40, null, 60, Map.width - 2, 10, Map.height - 2);
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


        //Places the orcs randomly on the map
        private static void RandomlyPlaceEnemy(Enemy enemy, string name, char icon, int health, int damage, string dir, int minX, int maxX, int minY, int maxY)
        {
            Random random = new Random();

            while (true)
            {
                int x = random.Next(minX, maxX);
                int y = random.Next(minY, maxY);

                if (Map.map[y, x] == '`')
                {
                    EnemyOrc.SetEnemy(enemy, name, x, y, icon, health, damage, dir);
                    break;
                }
            }
        }





    }
}
