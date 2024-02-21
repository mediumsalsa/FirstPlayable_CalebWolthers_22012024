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
                    Map.map[Enemy.enemyPosY, Enemy.enemyPosX] = '`';
                    Program.enemyChar = '`';
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
