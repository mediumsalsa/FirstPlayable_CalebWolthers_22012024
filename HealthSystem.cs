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
            if (entity == "player")
            {
                if (damage >= 0)
                {


                    if (Player.shield > 0)
                    {
                        int currentShield = Player.shield;
                        Player.shield -= damage;


                        int remainingDamage = damage -= currentShield;

                        if (remainingDamage >= 0)
                        {
                            health -= remainingDamage;

                            if (health <= 0)
                            {
                                GameManager.StartGame();
                            }

                        }
                    }
                    else if (health > 0)
                    {
                        health -= damage;

                        if (health <= 0)
                        {
                            GameManager.StartGame();
                        }

                    }

                    if (Player.shield <= 0)
                    {
                        Player.shield = 0;
                    }
                    if (health <= 0)
                    {
                        health = 0;
                        GameManager.StartGame();
                    }

                }

                else
                {
                    Console.WriteLine("Error. Damage cannot be a negative number.");
                    Console.WriteLine("Enemy is not trying to heal you.");
                    Console.WriteLine("");
                }
            }
            else
            {

                health -= damage;

                if (health <= 0)
                {
                    health = 0;
                    Map.map[enemy.enemyPosY, enemy.enemyPosX] = '`';
                    enemy.enemyChar = '`';
                    Map.DisplayMap();
                    Player.playerAttack += enemy.enemyDamage;
                    Enemy.enemyCount--;
                }
            }

        }



        public static void Heal(int heal, ref int health)
        {
            health += heal;
        }






    }
}
