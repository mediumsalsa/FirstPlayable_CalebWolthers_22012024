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

        static int numberOfMinotaurs = 6;
        static EnemyMinotaur[] minotaurs = new EnemyMinotaur[numberOfMinotaurs];

        static EnemyDragon dragon = new EnemyDragon();

        static int numberOfOrcs = 25;
        static EnemyOrc[] orcs = new EnemyOrc[numberOfOrcs];



        public static void StartEnemies()
        {
            Enemy.enemyCount = GetAllEnemies().Count();


            Enemy.SetEnemy(dragon, "Kinda Mighty Dragon", 92, 1, 'D', 10000, 100, null);

            for (int i = 0; i < numberOfMinotaurs; i++)
            {
                minotaurs[i] = new EnemyMinotaur();
                Enemy.RandomlyPlaceEnemy(minotaurs[i], "Minotaur", '}', 400, 50, null, 2, Map.width - 30, 2, Map.height - 13);
            }

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
            foreach (var enemy in GetAllEnemies())
            {
                enemy.MoveEnemy(enemy);
            }

            Map.DisplayMap();
        }

        public static void CheckForAllEnemies()
        {
            foreach (var enemy in GetAllEnemies())
            {
                Player.PlayerHitEnemy(enemy);
            }
        }


        private static IEnumerable<Enemy> GetAllEnemies()
        {
            yield return dragon;
            foreach (var minotaur in minotaurs) yield return minotaur;
            foreach (var goblin in goblins) yield return goblin;
            foreach (var orc in orcs) yield return orc;
        }





    }
}
