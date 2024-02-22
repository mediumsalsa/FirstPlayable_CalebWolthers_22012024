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
            Console.Clear();

            Console.SetCursorPosition(0, 0);

            Console.CursorVisible = !true;

            Console.WriteLine("");


            //Write your enemy stats here
            slime.enemyName = "Slime";
            slime.enemyPosX = 12;
            slime.enemyPosY = 12;
            slime.enemyChar = '0';
            slime.health = 100;
            slime.enemyDamage = 10;
            slime.enemyUp = true;

            goblin.enemyName = "Goblin";
            goblin.enemyPosX = 5;
            goblin.enemyPosY = 15;
            goblin.enemyChar = 'G';
            goblin.health = 150;
            goblin.enemyDamage = 20;
            goblin.enemyUp = false;

            bat.enemyName = "Hell Bat";
            bat.enemyPosX = 16;
            bat.enemyPosY = 16;
            bat.enemyChar = 'B';
            bat.health = 100;
            bat.enemyDamage = 30;

            rockGolem.enemyName = "Rock Golem";
            rockGolem.enemyPosX = 24;
            rockGolem.enemyPosY = 18;
            rockGolem.enemyChar = 'O';
            rockGolem.health = 300;
            rockGolem.enemyDamage = 12;


            Player.SetPlayer();

            Map.StartMap();


            //ADD THIS METHOD FOR YOU'RE NEW ENEMY
            Enemy.UpdateEnemy(slime);
            Enemy.UpdateEnemy(goblin);
            Enemy.UpdateEnemy(bat);
            Enemy.UpdateEnemy(rockGolem);



            GetInput();

            Console.WriteLine("");
        }


        //AND THIS METHOD FOR YOU'RE NEW ENEMY
        public static void MoveAllEnemies()
        {

            Enemy.MoveEnemyVert(slime);
            Enemy.MoveEnemyVert(goblin);
            Enemy.MoveEnemyRandom(bat);
            Enemy.MoveEnemyRandom(rockGolem);



            Map.DisplayMap();
        }

        //AND THIS METHOD FOR YOU'RE NEW ENEMY
        public static void CheckForAllEnemies()
        {

            PlayerHitEnemy(slime);
            PlayerHitEnemy(goblin);
            PlayerHitEnemy(bat);
            PlayerHitEnemy(rockGolem);

        }




        public static void CheckNextMove()
        {
            var ey = new Enemy();

            if (Player.playerPosX != Map.width - 1 && Player.playerPosY != Map.height - 1 && Player.playerPosX != 0 && Player.playerPosY != 0)
            {

                if (Map.map[Player.playerPosY, Player.nextPosX] == '^' || Map.map[Player.nextPosY, Player.playerPosX] == '^')
                {
                    Player.CantMove();

                    Map.lastItem = "Health Potion(+60 health)";
                    HealthSystem.TakeDamage("player", 60, ref Player.health, null);
                }
                else if (Map.map[Player.playerPosY, Player.nextPosX] == '~' || Map.map[Player.nextPosY, Player.playerPosX] == '~')
                {
                    Player.CantMove();
                }
                else if (Map.map[Player.playerPosY, Player.nextPosX] == '#' || Map.map[Player.nextPosY, Player.playerPosX] == '#')
                {
                    Player.CantMove();
                }
                else if (Map.map[Player.playerPosY, Player.nextPosX] == '@' || Map.map[Player.nextPosY, Player.playerPosX] == '@')
                {
                    HealthSystem.Heal(40, ref Player.health);
                }
                else if (Map.map[Player.playerPosY, Player.nextPosX] == '7' || Map.map[Player.nextPosY, Player.playerPosX] == '7')
                {
                    Map.lastItem = "Golems Greatsword(+50 attack)";
                    Player.playerAttack += 50;
                }


                CheckForAllEnemies();


            }

        }

        public static void PlayerHitEnemy(Enemy ey)
        {
            if (Map.map[Player.playerPosY, Player.nextPosX] == Map.map[ey.enemyPosY, ey.enemyPosX] || Map.map[Player.nextPosY, Player.playerPosX] == Map.map[ey.enemyPosY, ey.enemyPosX])
            {
                if (ey.health > 0)
                {
                    Player.CantMove();

                    HealthSystem.TakeDamage("enemy", 50, ref ey.health, ey);

                    Map.UpdateHUD(ey);
                }
            }
        }





        public static void GetInput()
        {
            var exit = false;

            ConsoleKeyInfo keyInfo;

            do
            {

                keyInfo = Console.ReadKey(true);

                Console.WriteLine();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        Player.KeyW();
                        MoveAllEnemies();
                        break;

                    case ConsoleKey.A:
                        Player.KeyA();
                        MoveAllEnemies();
                        break;

                    case ConsoleKey.S:
                        Player.KeyS();
                        MoveAllEnemies();
                        break;

                    case ConsoleKey.D:
                        Player.KeyD();
                        MoveAllEnemies();
                        break;

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;

                    case ConsoleKey.R:
                        StartGame();
                        break;

                    default:
                        //ExitProgram();
                        break;

                }



            }


            while (exit == false);

        }


    }
}
