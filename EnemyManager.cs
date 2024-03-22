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
            InitializeEnemies();

            Enemy.enemyCount = GetAllEnemies().Count();

            foreach (var enemy in GetAllEnemies())
            {
                if (enemy != null)
                {
                    Enemy.RandomlyPlaceEnemy(enemy, enemy.enemyName, enemy.enemyChar, enemy.enemyHealth, enemy.enemyDamage, enemy.enemyDir, enemy.enemyMinX, enemy.enemyMaxX, enemy.enemyMinY, enemy.enemyMaxY);
                }
            }
        }


        private static void InitializeEnemies()
        {
            for (int i = 0; i < numberOfGoblins; i++)
            {
                goblins[i] = new EnemyGoblin();
            }

            for (int i = 0; i < numberOfMinotaurs; i++)
            {
                minotaurs[i] = new EnemyMinotaur();
            }

            for (int i = 0; i < numberOfOrcs; i++)
            {
                orcs[i] = new EnemyOrc();
            }
        }
        private static IEnumerable<Enemy> GetAllEnemies()
        {
            yield return dragon;
            foreach (var minotaur in minotaurs) yield return minotaur;
            foreach (var goblin in goblins) yield return goblin;
            foreach (var orc in orcs) yield return orc;
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








    }
}
