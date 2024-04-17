using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class EnemyManager
    {

        private Player player;
        private Map map;
        public List<Enemy> enemies;
        public HealthSystem healthSystem;

        public EnemyManager(Player player, Map map)
        {
            this.player = player;
            this.map = map;
            this.healthSystem = healthSystem;
            enemies = new List<Enemy>();
            
        }


        public void PlaceGoblins(int goblinNum)
        {
            Random random = new Random();

            for (int i = 0; i < goblinNum; i++)
            {
                while (true)
                {
                    int x = random.Next(8, map.width - 70);
                    int y = random.Next(16, map.height - 2);

                    if (map.map[y, x] == '`')
                    {
                        EnemyGoblin goblin = new EnemyGoblin(map, player);
                        goblin.posX = x;
                        goblin.posY = y;
                        goblin.health = 150;
                        map.map[y, x] = goblin.Char;
                        enemies.Add(goblin);
                        break;
                    }
                }
            }
        }


        public void UpdateEnemies()
        {
            foreach (Enemy enemy in enemies) 
            {
                enemy.Update();
            }
        }

        public void DrawEnemies()
        {
            foreach(Enemy enemy in enemies) 
            {
                enemy.Draw();
            }
        }


    }
}
/*
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



        public static void UpdateEnemies()
        {
            foreach (var enemy in GetAllEnemies())
            {
                enemy.Update(enemy);
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
}*/