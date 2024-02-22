using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class HealthSystem
    {

        public static void TakeDamage(string entity, int damage, ref int health, Enemy enemy)
        {

            health -= damage;

            if (health <= 0)
            {
                
                health = 0;
                if (entity == "player")
                {
                    GameManager.StartGame();
                }
                else 
                {
                    Map.map[enemy.enemyPosY, enemy.enemyPosX] = '`';
                    enemy.enemyChar = '`';
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
