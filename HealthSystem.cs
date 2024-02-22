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


                    Console.WriteLine("Incoming damage: " + damage);
                    Console.WriteLine("");

                    if (Player.shield > 0)
                    {
                        int currentShield = Player.shield;
                        Player.shield -= damage;

                        if (damage <= Player.shield)
                        {
                            Console.WriteLine("Player has taken " + damage + " damage to their shield!");
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Player has taken " + currentShield + " damage to their shield!");
                        }


                        int remainingDamage = damage -= currentShield;

                        if (remainingDamage >= 0)
                        {
                            Console.WriteLine("Shield has been destroyed!");
                            Console.WriteLine("");
                            health -= remainingDamage;

                            if (health <= 0)
                            {
                                Console.WriteLine("Player Has Died");
                            }
                            else
                            {
                                Console.WriteLine("Player has taken an additional " + remainingDamage + " damage to their health");
                                Console.WriteLine("");
                            }
                        }
                    }
                    else if (health > 0)
                    {
                        health -= damage;

                        if (health <= 0)
                        {
                            Console.WriteLine("Player Has Died");
                        }
                        else
                        {
                            Console.WriteLine("Player has taken " + damage + " damage to their health!");
                            Console.WriteLine("");
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
