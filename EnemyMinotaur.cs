using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class EnemyMinotaur : Enemy
    {
        public static new string enemyName = "Minotaur";
        public static new char enemyChar = '}';
        public static new int enemyHealth = 400;
        public static new int enemyDamage = 50;
        public static new string enemyDir;

        public static new int enemyMinX = 2;
        public static new int enemyMaxX = Map.width - 30;
        public static new int enemyMinY = 2;
        public static new int enemyMaxY = Map.height - 13;



        public static int chaseDistance = 5;

        public override void MoveEnemy(Enemy ey)
        {
            if (ey.enemyChar != '`')
            { 
                int diffX = Player.playerPosX - ey.enemyPosX;
                int diffY = Player.playerPosY - ey.enemyPosY;

                if (Math.Abs(diffX) <= chaseDistance && Math.Abs(diffY) <= chaseDistance)
                {
                    string nextDir = (Math.Abs(diffX) > Math.Abs(diffY)) ? ((diffX > 0) ? "right" : "left") : ((diffY > 0) ? "down" : "up");

                    EnemyMove(ey, (nextDir == "left") ? -1 : ((nextDir == "right") ? 1 : 0), (nextDir == "up") ? -1 : ((nextDir == "down") ? 1 : 0), null);
                }
            }

        }


    }
}
