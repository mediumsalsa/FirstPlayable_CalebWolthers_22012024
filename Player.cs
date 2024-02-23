using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Player : Entity
    {


        public static int health = 100;
        public static int shield = 0;

        public static int playerAttack = 50;

        public int xp;
        public int level;
        public int score;

        public static int playerPosX;
        public static int playerPosY;

        public static string dir;

        public static int nextPosX;
        public static int nextPosY;

        public static int lastPosX;
        public static int lastPosY;

        public static int oldPosX;
        public static int oldPosY;

        public static void SetPlayer()
        {
            Player.health = 100;

            Player.shield = 0;

            Player.playerAttack = 50;

            Player.gameChar = 'P';

            playerPosX = 4;
            playerPosY = 20;

            
        }



        public static void KeyW()
        {
            dir = "up";

            nextPosY = playerPosY - 1;

            lastPosY = playerPosY;
            lastPosX = playerPosX;

            if (playerPosY != 0 )
            {

                oldPosY = playerPosY;

                GameManager.CheckNextMove();

                playerPosY = nextPosY;

                PlayerMoved();
            }

        }


        public static void KeyA()
        {
            dir = "left";

            nextPosX = playerPosX - 1;

            lastPosY = playerPosY;
            lastPosX = playerPosX;

            if (playerPosX != 0 )
            {

                oldPosX = playerPosX;

                GameManager.CheckNextMove();

                playerPosX = nextPosX;

                PlayerMoved();
            }

        }

        public static void KeyS()
        {
            dir = "down";

            nextPosY = playerPosY + 1;

            lastPosY = playerPosY;
            lastPosX = playerPosX;

            if (playerPosY != Map.height - 1)
            {

                oldPosY = playerPosY;

                GameManager.CheckNextMove();

                playerPosY = nextPosY;

                PlayerMoved();
            }
        }


        public static void KeyD()
        {
            dir = "right";

            nextPosX = playerPosX + 1;

            lastPosY = playerPosY;
            lastPosX = playerPosX;

            if (playerPosX != Map.width - 1)
            {
                oldPosX = playerPosX;

                GameManager.CheckNextMove();

                playerPosX = nextPosX;

                PlayerMoved();
            }


        }

        public static void CantMove()
        {
            if (dir == "up" || dir == "down")
            {
                nextPosY = oldPosY;
            }
            else if (dir == "left" || dir == "right")
            {
                nextPosX = oldPosX;
            }
        }


        public static void PlayerMoved()
        {
            Map.map[lastPosY, lastPosX] = '`';

            Map.map[playerPosY, playerPosX] = Player.gameChar;

        }





    }




}