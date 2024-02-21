using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Reflection.Emit;





namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Program
    {


        //Enemy Holding zone
         static Enemy slime = new Enemy();

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
        //

        

        static void Main(string[] args)
        {

            Console.WriteLine("Start Game");
            Console.WriteLine("");

            StartGame();

            Console.WriteLine("");
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey(true);

        }

        public static void StartGame()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 0);

            Console.CursorVisible = !true;

            Console.WriteLine("");

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
            bat.enemyDamage = 40;


            Player.SetPlayer();

            Map.StartMap();

            Enemy.UpdateEnemy(slime);
            Enemy.UpdateEnemy(goblin);
            Enemy.UpdateEnemy(bat);

            GetInput();

            Console.WriteLine("");
        }



        public static void MoveAllEnemies()
        {
            Enemy.MoveEnemyVert(slime);
            Enemy.MoveEnemyVert(goblin);
            Enemy.MoveEnemyRandom(bat);
            Map.DisplayMap();
        }




        public static void CheckNextMove()
        {
            var ey = new Enemy();

            if (Player.playerPosX != Map.width - 1 && Player.playerPosY != Map.height - 1 && Player.playerPosX != 0 && Player.playerPosY != 0)
            {

                if (Map.map[Player.playerPosY, Player.nextPosX] == '^' || Map.map[Player.nextPosY, Player.playerPosX] == '^')
                {
                    Player.CantMove();

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
                else if (Map.map[Player.playerPosY, Player.nextPosX] == Map.map[slime.enemyPosY, slime.enemyPosX] || Map.map[Player.nextPosY, Player.playerPosX] == Map.map[slime.enemyPosY, slime.enemyPosX])
                {
                    if (slime.health > 0)
                    { 
                        Player.CantMove();

                        HealthSystem.TakeDamage("enemy", 50, ref slime.health, slime);

                        Map.UpdateHUD(slime);
                    }
                }
                else if (Map.map[Player.playerPosY, Player.nextPosX] == Map.map[goblin.enemyPosY, goblin.enemyPosX] || Map.map[Player.nextPosY, Player.playerPosX] == Map.map[goblin.enemyPosY, goblin.enemyPosX])
                {
                    if (goblin.health > 0)
                    {
                        Player.CantMove();

                        HealthSystem.TakeDamage("enemy", 50, ref goblin.health, goblin);

                        Map.UpdateHUD(goblin);
                    }
                }
                else if (Map.map[Player.playerPosY, Player.nextPosX] == Map.map[bat.enemyPosY, bat.enemyPosX] || Map.map[Player.nextPosY, Player.playerPosX] == Map.map[bat.enemyPosY, bat.enemyPosX])
                {
                    if (bat.health > 0)
                    {
                        Player.CantMove();

                        HealthSystem.TakeDamage("enemy", 50, ref bat.health, bat);

                        Map.UpdateHUD(bat);
                    }
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
                        Program.StartGame();
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