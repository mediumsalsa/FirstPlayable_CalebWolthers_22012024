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


        static Enemy slime = new Enemy();
        static Enemy goblin = new Enemy();

        static Enemy bat = new Enemy();



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
            goblin.enemyPosY = 5;
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
            Enemy.SetEnemy(slime.enemyName, slime.enemyPosX, slime.enemyPosY, slime.enemyChar, slime.health, slime.enemyUp, slime.enemyDamage);
            Enemy.SetEnemy(goblin.enemyName, goblin.enemyPosX, goblin.enemyPosY, goblin.enemyChar, goblin.health, goblin.enemyUp, goblin.enemyDamage);
            Enemy.SetEnemy(bat.enemyName, bat.enemyPosX, bat.enemyPosY, bat.enemyChar, bat.health, bat.enemyUp, bat.enemyDamage);
            Map.StartMap();

            Map.map[slime.enemyPosY, slime.enemyPosX] = slime.enemyChar;
            Map.map[goblin.enemyPosY, goblin.enemyPosX] = goblin.enemyChar;
            Map.map[bat.enemyPosY, bat.enemyPosX] = bat.enemyChar;

            GetInput();

            Console.WriteLine("");
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

                        break;

                    case ConsoleKey.A:
                        Player.KeyA();

                        break;

                    case ConsoleKey.S:
                        Player.KeyS();

                        break;

                    case ConsoleKey.D:
                        Player.KeyD();

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
                MoveAllEnemies();


            }


            while (exit == false);

        }




        public static void MoveAllEnemies()
        {
            Enemy.MoveEnemyVert(ref slime.enemyPosX, ref slime.enemyPosY, ref slime.enemyUp, slime.enemyChar, slime);
            Enemy.MoveEnemyVert(ref goblin.enemyPosX, ref goblin.enemyPosY, ref goblin.enemyUp, goblin.enemyChar, goblin);
            Enemy.MoveEnemyRandom(ref bat.enemyPosX, ref bat.enemyPosY, bat.enemyChar, bat);
            Map.DisplayMap();
        }





    }
}