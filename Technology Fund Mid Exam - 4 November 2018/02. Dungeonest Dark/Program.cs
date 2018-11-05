using System;
using System.Linq;

namespace _02._Dungeonest_Dark
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int health = 100;
            int coins = 0;
            bool isDead = false;
            int room = 0;

            for (int i = 0; i < input.Length; i+=2)
            {
                room++;
                if (input[i]=="potion")
                {
                    if (health+int.Parse(input[i+1])>100)
                    {
                        Console.WriteLine($"You healed for {100-health} hp.");
                        Console.WriteLine($"Current health: {100} hp.");
                        health = 100;
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {int.Parse(input[i + 1])} hp.");
                        Console.WriteLine($"Current health: {health + int.Parse(input[i + 1])} hp.");
                        health +=int.Parse(input[i + 1]);
                    }
                }
                else if (input[i]== "chest")
                {
                    coins += int.Parse(input[i + 1]);
                    Console.WriteLine($"You found {int.Parse(input[i+1])} coins.");
                }
                else
                {
                    if (int.Parse(input[i+1])<health)
                    {
                        Console.WriteLine($"You slayed {input[i]}.");
                        health -= int.Parse(input[i + 1]);
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {input[i]}.");
                        Console.WriteLine($"Best room: {room}");
                        isDead = true;
                        break;
                    }
                }
            }

            if (!isDead)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Coins: {coins}");
                Console.WriteLine($"Health: {health}");
            }


        }
    }
}
