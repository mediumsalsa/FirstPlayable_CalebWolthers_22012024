using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Settings
    {

        public static int width = 109;
        public static int height = 24;


        //---------------
        //Camera Settings
        //---------------
        public static int cameraWidth = 400;
        public static int cameraHeight = 150;

        //---------------
        //Player Settings
        //---------------
        public static char playerChar = 'P';

        public static int playerHealth = 100;
        public static int playerShield = 0;
        public static int playerAttack = 100;

        public static int playerStartPosX = 4;
        public static int playerStartPosY = 20;

        //-------------
        //Item Settings
        //-------------

        //Health Potion Settings



        //--------------
        //Enemy Settings
        //--------------

        //Dragon Settings
        public static char dragonChar = 'D';
        public static string dragonName = "Dragon";
        public static int dragonHealth = 10000;
        public static int dragonDamage = 100;
        public static int dragonMinX = 85;
        public static int dragonMaxX = width - 10;
        public static int dragonMinY = 2;
        public static int dragonMaxY = height - 14;

        //Goblin Settings
        public static char goblinChar = 'G';
        public static string goblinName = "Goblin";
        public static int goblinHealth = 150;
        public static int goblinDamage = 20;
        public static string goblinDir = "down";
        public static int goblinMinX = 8;
        public static int goblinMaxX = width - 70;
        public static int goblinMinY = 16;
        public static int goblinMaxY = height - 2;

        //Orc Settings
        public static char orcChar = 'O';
        public static string orcName = "Orc";
        public static int orcHealth = 200;
        public static int orcDamage = 40;
        public static int orcMinX = 60;
        public static int orcMaxX = width - 2;
        public static int orcMinY = 10;
        public static int orcMaxY = height - 2;

        //Minotaur Settings
        public static char minotaurChar = '}';
        public static string minotaurName = "Minotaur";
        public static int minotaurHealth = 400;
        public static int minotaurDamage = 50;
        public static int minotaurMinX = 2;
        public static int minotaurMaxX = width - 30;
        public static int minotaurMinY = 2;
        public static int minotaurMaxY = height - 13;

    }
}
