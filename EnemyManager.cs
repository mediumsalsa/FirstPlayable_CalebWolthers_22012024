using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class EnemyManager
    {



        private static List<Enemy> enemies;
        

        //static Enemy[] enemies = new Enemy[] { new EnemyGoblin(), new EnemyOrc(), new EnemyMinotaur(), new EnemyDragon() }; 


        public static void StartEnemies()
        {
            InitializeEnemies();

            //Enemy.enemyCount = enemies.Length;

            foreach (Enemy enemy in enemies)
            {
                if (enemy != null)
                {
                    Enemy.RandomlyPlaceEnemy(enemy, enemy.enemyName, enemy.enemyChar, enemy.enemyHealth, enemy.enemyDamage, enemy.enemyDir, enemy.enemyMinX, enemy.enemyMaxX, enemy.enemyMinY, enemy.enemyMaxY);
                }
            }
        }


        private static void InitializeEnemies()
        {
            enemies.Add(new EnemyGoblin());
            enemies.Add(new EnemyOrc());
            enemies.Add(new EnemyMinotaur());
            enemies.Add(new EnemyDragon());

            /* for (int i = 0; i < numberOfGoblins; i++)
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
            } */
        }


        public static void UpdateEnemies()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Update(enemy);
            }

            Map.DisplayMap();
        }

        public static void CheckForAllEnemies()
        {
            foreach (Enemy enemy in enemies)
            {
                Player.PlayerHitEnemy(enemy);
            }
        }








    }
}
