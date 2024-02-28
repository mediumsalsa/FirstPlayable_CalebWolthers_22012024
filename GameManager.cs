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

        static Enemy bat = new Enemy();

        static Enemy minotaur = new Enemy();

        static Enemy skele = new Enemy();

        static Enemy dragon = new Enemy();

        static Enemy guardian = new Enemy();


        //
        //Process to add enemies:
        //  1.  Instantiate in the enemy holding zone.
        //  2.  Give the enmy it's stats in the start game method.
        //  3.  Update the enemy. Also in the start game method
        //  4.  Give the enemy it's movement script in the MoveAllEnemies method.
        //  5.  tell the player what happens when it hits the enmy in the check next move method
        //
        // NOTE: you do not need to go through other classes to add an enemy
        //  
        //


        public static void StartGame()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);


            Console.Clear();

            Console.SetCursorPosition(0, 0);

            Console.CursorVisible = !true;



            //Write your enemy stats here
            slime.enemyName = "Useless Slime";
            slime.enemyPosX = 12;
            slime.enemyPosY = 12;
            slime.enemyChar = '0';
            slime.health = 100;
            slime.enemyDamage = 10;
            slime.enemyDir = "up";


            goblin.enemyName = "Goblin";
            goblin.enemyPosX = 5;
            goblin.enemyPosY = 15;
            goblin.enemyChar = 'G';
            goblin.health = 150;
            goblin.enemyDamage = 20;
            goblin.enemyDir = "down";


            bat.enemyName = "Bones, The Twin Golem";
            bat.enemyPosX = 16;
            bat.enemyPosY = 16;
            bat.enemyChar = 'B';
            bat.health = 100;
            bat.enemyDamage = 30;

            rockGolem.enemyName = "Rock, The Other Twin Golem";
            rockGolem.enemyPosX = 24;
            rockGolem.enemyPosY = 18;
            rockGolem.enemyChar = 'O';
            rockGolem.health = 300;
            rockGolem.enemyDamage = 12;

            minotaur.enemyName = "Purple Minotaur";
            minotaur.enemyPosX = 40;
            minotaur.enemyPosY = 9;
            minotaur.enemyChar = '}';
            minotaur.health = 500;
            minotaur.enemyDamage = 30;
            minotaur.enemyDir = "right";

            skele.enemyName = "Skeleton";
            skele.enemyPosX = 6;
            skele.enemyPosY = 4;
            skele.enemyChar = '$';
            skele.health = 300;
            skele.enemyDamage = 40;
            skele.enemyDir = "up";

            dragon.enemyName = "Kinda Mighty Dragon";
            dragon.enemyPosX = 32;
            dragon.enemyPosY = 15;
            dragon.enemyChar = 'D';
            dragon.health = 1000;
            dragon.enemyDamage = 40;

            guardian.enemyName = "Royal Guardian";
            guardian.enemyPosX = 6;
            guardian.enemyPosY = 12;
            guardian.enemyChar = '!';
            guardian.health = 350;
            guardian.enemyDamage = 150;
            guardian.enemyDir = "up";


            Player.SetPlayer();

            Map.StartMap();



            Enemy.UpdateEnemy(slime);
            Enemy.UpdateEnemy(goblin);
            Enemy.UpdateEnemy(bat);
            Enemy.UpdateEnemy(rockGolem);
            Enemy.UpdateEnemy(minotaur);
            Enemy.UpdateEnemy(skele);
            Enemy.UpdateEnemy(dragon);
            Enemy.UpdateEnemy(guardian);



            Player.GetInput();

        }



        public static void MoveAllEnemies()
        {

            Enemy.MoveEnemyVert(slime);
            Enemy.MoveEnemyVert(goblin);
            Enemy.MoveEnemyRandom(bat);
            Enemy.MoveEnemyRandom(rockGolem);
            Enemy.MoveEnemySquare(minotaur);
            Enemy.MoveEnemySquare(skele);
            Enemy.MoveEnemyRandom2(dragon);
            Enemy.MoveEnemyPatrol(guardian);



            Map.DisplayMap();
        }


        public static void CheckForAllEnemies()
        {

            PlayerHitEnemy(slime);
            PlayerHitEnemy(goblin);
            PlayerHitEnemy(bat);
            PlayerHitEnemy(rockGolem);
            PlayerHitEnemy(minotaur);
            PlayerHitEnemy(skele);
            PlayerHitEnemy(dragon);
            PlayerHitEnemy(guardian);

        }






        public static void PlayerHitEnemy(Enemy ey)
        {
            if (Map.map[Player.playerPosY, Player.nextPosX] == Map.map[ey.enemyPosY, ey.enemyPosX] || Map.map[Player.nextPosY, Player.playerPosX] == Map.map[ey.enemyPosY, ey.enemyPosX])
            {
                if (ey.health > 0)
                {
                    Player.CantMove();

                    HealthSystem.TakeDamage("enemy", Player.playerAttack, ref ey.health, ey);

                    Map.UpdateHUD(ey);
                }
            }
        }




    }
}
