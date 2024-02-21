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




        static Player player = new Player();
        static Enemy slime = new Enemy();
        static Enemy goblin = new Enemy();
        static Item sword = new Item();


        static void Main(string[] args)
        {

            Console.WriteLine("Start Game");
            Console.WriteLine("");

            slime.enemyPosX = 12;
            slime.enemyPosY = 12;
            slime.enemyChar = '0';
            slime.health = 100;
            slime.enemyUp = true;

            goblin.enemyPosX = 5;
            goblin.enemyPosY = 5;
            goblin.enemyChar = '3';
            goblin.health = 100;
            slime.enemyUp = false;

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

            Player.SetPlayer();
            Enemy.SetEnemy(slime.enemyPosX, slime.enemyPosY, slime.enemyChar, slime.health, slime.enemyUp);
            Enemy.SetEnemy(goblin.enemyPosX, goblin.enemyPosY, goblin.enemyChar, goblin.health, goblin.enemyUp);
            Map.StartMap();

            Map.map[slime.enemyPosX, slime.enemyPosY] = slime.enemyChar;
            Map.map[goblin.enemyPosX, goblin.enemyPosY] = goblin.enemyChar;

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

                        HealthSystem.TakeDamage("enemy", 60, ref slime.health, slime);
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
                        Enemy.MoveEnemy(ref slime.enemyPosX, ref slime.enemyPosY, ref slime.enemyUp, slime.enemyChar);
                        Enemy.MoveEnemy(ref goblin.enemyPosX, ref goblin.enemyPosY, ref goblin.enemyUp, goblin.enemyChar);
                        break;

                    case ConsoleKey.A:
                        Player.KeyA();
                        Enemy.MoveEnemy(ref slime.enemyPosX, ref slime.enemyPosY, ref slime.enemyUp, slime.enemyChar);
                        Enemy.MoveEnemy(ref goblin.enemyPosX, ref goblin.enemyPosY, ref goblin.enemyUp, goblin.enemyChar);
                        break;

                    case ConsoleKey.S:
                        Player.KeyS();
                        Enemy.MoveEnemy(ref slime.enemyPosX, ref slime.enemyPosY, ref slime.enemyUp, slime.enemyChar);
                        Enemy.MoveEnemy(ref goblin.enemyPosX, ref goblin.enemyPosY, ref goblin.enemyUp, goblin.enemyChar);
                        break;

                    case ConsoleKey.D:
                        Player.KeyD();
                        Enemy.MoveEnemy(ref slime.enemyPosX, ref slime.enemyPosY, ref slime.enemyUp, slime.enemyChar);
                        Enemy.MoveEnemy(ref goblin.enemyPosX, ref goblin.enemyPosY, ref goblin.enemyUp, goblin.enemyChar);
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







       /* public static void KeyW()
        {
            var ey = new Enemy();
            Player.nextPosY = Player.playerPosY - 1;

            Player.lastPosY = Player.playerPosY;
            Player.lastPosX = Player.playerPosX;

            if (Player.playerPosY != 0 && Map.map[Player.nextPosY, Player.playerPosX] != '#' && Map.map[Player.nextPosY, Player.playerPosX] != '~')
            {

                if (Map.map[Player.nextPosY, Player.playerPosX] == Map.map[slime.enemyPosY, slime.enemyPosX] && slime.health > 0)
                {
                    HealthSystem.TakeDamage("enemy", 60, ref slime.health, slime);
                }
                else if (Map.map[Player.nextPosY, Player.playerPosX] == '^')
                {
                    HealthSystem.TakeDamage("player", 60, ref Player.health, null);
                }
                else
                {
                    if (Map.map[Player.nextPosY, Player.playerPosX] == '@')
                    {
                        HealthSystem.Heal(40, ref Player.health);
                    }

                    Player.oldPosY = Player.playerPosY;

                    Player.playerPosY = Player.nextPosY;

                    Player.CheckNextMove();

                    Player.PlayerMoved();

                    Enemy.MoveEnemy(ref slime.enemyPosX, ref slime.enemyPosY, ref slime.enemyUp, slime.enemyChar);
                    Enemy.MoveEnemy(ref goblin.enemyPosX, ref goblin.enemyPosY, ref goblin.enemyUp, goblin.enemyChar);

                    Console.WriteLine("W");
                }
            }

        }


        public static void KeyA()
        {
            var ey = new Enemy();

            Player.nextPosX = Player.playerPosX - 1;

            Player.lastPosY = Player.playerPosY;
            Player.lastPosX = Player.playerPosX;

            if (Player.playerPosX != 0 && Map.map[Player.playerPosY, Player.nextPosX] != '#' && Map.map[Player.playerPosY, Player.nextPosX] != '~')
            {


                if (Map.map[Player.playerPosY, Player.nextPosX] == Map.map[slime.enemyPosY, slime.enemyPosX] && slime.health > 0)
                {
                    HealthSystem.TakeDamage("enemy", 60, ref ey.health, slime);
                }
                else if (Map.map[Player.playerPosY, Player.nextPosX] == '^')
                {
                    HealthSystem.TakeDamage("player", 60, ref Player.health, null);
                }
                else
                {
                    if (Map.map[Player.playerPosY, Player.nextPosX] == '@')
                    {
                        HealthSystem.Heal(40, ref Player.health);
                    }

                    Player.oldPosX = Player.playerPosX;

                    Player.playerPosX = Player.nextPosX;

                    Player.CheckNextMove();

                    Player.PlayerMoved();

                    Enemy.MoveEnemy(ref slime.enemyPosX, ref slime.enemyPosY, ref slime.enemyUp, slime.enemyChar);
                    Enemy.MoveEnemy(ref goblin.enemyPosX, ref goblin.enemyPosY, ref goblin.enemyUp, goblin.enemyChar);

                    Console.WriteLine("A");
                }
            }

        }

        public static void KeyS()
        {
            var ey = new Enemy();

            Player.nextPosY = Player.playerPosY + 1;

            Player.lastPosY = Player.playerPosY;
            Player.lastPosX = Player.playerPosX;

            if (Player.playerPosY != Map.height - 1 && Map.map[Player.nextPosY, Player.playerPosX] != '#' && Map.map[Player.nextPosY, Player.playerPosX] != '~')
            {

                if (Map.map[Player.nextPosY, Player.playerPosX] == Map.map[slime.enemyPosY, slime.enemyPosX] && slime.health > 0)
                {
                    HealthSystem.TakeDamage("enemy", 60, ref ey.health, slime);
                }
                else if (Map.map[Player.nextPosY, Player.playerPosX] == '^')
                {
                    HealthSystem.TakeDamage("player", 60, ref Player.health, null);
                }
                else
                {
                    if (Map.map[Player.nextPosY, Player.playerPosX] == '@')
                    {
                        HealthSystem.Heal(40, ref Player.health);
                    }


                    Player.oldPosY = Player.playerPosY;

                    Player.playerPosY = Player.nextPosY;

                    Player.CheckNextMove();

                    Player.PlayerMoved();

                    Enemy.MoveEnemy(ref slime.enemyPosX, ref slime.enemyPosY, ref slime.enemyUp, slime.enemyChar);
                    Enemy.MoveEnemy(ref goblin.enemyPosX, ref goblin.enemyPosY, ref goblin.enemyUp, goblin.enemyChar);

                    Console.WriteLine("S");
                }
            }

        }


        public static void KeyD()
        {
            var ey = new Enemy();

            Player.nextPosX = Player.playerPosX + 1;

            Player.lastPosY = Player.playerPosY;
            Player.lastPosX = Player.playerPosX;

            if (Player.playerPosX != Map.width - 1 && Map.map[Player.playerPosY, Player.nextPosX] != '#' && Map.map[Player.playerPosY, Player.nextPosX] != '~')
            {

                if (Map.map[Player.playerPosY, Player.nextPosX] == Map.map[slime.enemyPosY, slime.enemyPosX] && slime.health > 0)
                {
                    HealthSystem.TakeDamage("enemy", 40, ref ey.health, slime);
                }
                else if (Map.map[Player.playerPosY, Player.nextPosX] == '^')
                {
                    HealthSystem.TakeDamage("player", 60, ref Player.health, null);
                }
                else
                {
                    if (Map.map[Player.playerPosY, Player.nextPosX] == '@')
                    {
                        HealthSystem.Heal(40, ref Player.health);
                    }

                    Player.oldPosX = Player.playerPosX;

                    Player.playerPosX = Player.nextPosX;

                    Player.CheckNextMove();

                    Player.PlayerMoved();

                    Enemy.MoveEnemy(ref slime.enemyPosX, ref slime.enemyPosY, ref slime.enemyUp, slime.enemyChar);
                    Enemy.MoveEnemy(ref goblin.enemyPosX, ref goblin.enemyPosY, ref goblin.enemyUp, goblin.enemyChar);

                    Console.WriteLine("D");
                }
            }


        }*/


        public static void MoveAllEnemies()
        { 
            
        }




    }
}