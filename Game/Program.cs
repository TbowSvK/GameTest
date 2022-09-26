using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            //Definuji pole moznosti, jak se nepritel muze jmenovat
            string[] firstName = { "Evil", "Bad", "Undead" };
            string[] lastName = { "Skeleton", "Zombie", "Bat", "Wizard" };
            
            //Vytvarim nahodneho enemy s random atributy
            Enemy enemy = new Enemy(random.Next(10, 21), random.Next(1, 11), $"{firstName[random.Next(0, firstName.Length - 1)]} {lastName[random.Next(0, lastName.Length - 1)]}");

            Console.WriteLine("What will be your name?");
            string playerName = Console.ReadLine();
            
            //Aby jsem mohl pristupovat k playerovi i mimo while loopu, musim si ho preddefinovat, nasledne mu atributy priradim podle zvolene obtiznosti
            Player player;
            
            //Deklarace promenne, ktera slouzi k zvoleni obtiznosti, podle StackOverflow je to rychlejsi postup.
            int difficultyInt;

            //Volba obtiznosti
            while (true)
            {
                Console.WriteLine("Select difficulty:\n 0 - Easy\n 1 - Normal\n 2 - Hard");
                string difficulty = Console.ReadLine();

                if (int.TryParse(difficulty, out difficultyInt) && difficultyInt >= 0 && difficultyInt <= 2)
                {
                    player = new Player(200 - (difficultyInt * 50), 20 - (difficultyInt * 5), playerName, 20 - (difficultyInt * 5));
                    break;
                }
                else
                {
                    Console.WriteLine("Selected difficulty is wrong, pleas try again.");
                }
            }

            string action;
            //Game logic
            while (player.hp >= 0)
            {
                Console.WriteLine("What you wanna do?");
                action = Console.ReadLine();

                if (action == "attack")
                {
                    player.Attack(enemy, random.Next(0, player.damage + 1));
                    if (enemy.hp <= 0)
                    {
                        player.slayedEnemys += 1;
                        enemy.Reroll(random.Next(10, 21), random.Next(1, 11), $"{firstName[random.Next(0, firstName.Length - 1)]} {lastName[random.Next(0, lastName.Length - 1)]}");
                        continue;
                    }
                }
                else if (action == "heal")
                {
                    player.Heal(random.Next(0, player.healingPower + 1));
                }
                else if (action == "status")
                {
                    Console.WriteLine(player.name);
                    Console.WriteLine("=================");
                    Console.WriteLine($"HP {player.hp}/{player.maxHp}");
                    Console.WriteLine($"Damage {player.damage}");
                    Console.WriteLine($"Healing power {player.healingPower}");
                    Console.WriteLine($"Enemy slayed {player.slayedEnemys}");
                    continue;
                }
                else if (action == "help")
                {
                    Console.WriteLine("Write attack for attacking enemy.");
                    Console.WriteLine("Write heal for healing the player.");
                    Console.WriteLine("Write status for display players status.");
                    Console.WriteLine("Bored? Write suicide.");
                    
                    continue;
                }
                else if (action == "suicide")
                {
                    Console.WriteLine("Bye.");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input, write help, for possible actions.");
                    continue;
                }

                enemy.Attack(player, random.Next(0, enemy.damage + 1));

            }

            Console.WriteLine("You have died!");
        }
    }
}
