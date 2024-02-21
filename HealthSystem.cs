using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class HealthSystem
    {

        public static void TakeDamage(string entity, int damage, ref int health)
        {
            var ey = new Enemy();

            health -= damage;

            if (health <= 0)
            {
                
                health = 0;
                if (entity == "player")
                {
                    Program.StartGame();
                }
                else
                {
                    Map.map[ey.enemyPosY, ey.enemyPosX] = '`';
                    ey.enemyChar = '`';
                    Map.DisplayMap();
                }
            }

        }

        public static void Heal(int heal, ref int health)
        {
            health += heal;
        }






    }
}
