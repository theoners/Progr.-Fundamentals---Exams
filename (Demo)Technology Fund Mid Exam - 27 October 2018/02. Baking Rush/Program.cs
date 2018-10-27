using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Baking_Rush
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(new char[] { '-', '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            int energy = 100;
            int coin = 100;

            for (int i = 0; i < input.Count; i++)
            {
                if (i % 2 == 0)
                {
                    if (input[i] == "rest")
                    {
                        int gainedEnergy = int.Parse(input[i + 1]);

                        if (energy + gainedEnergy > 100)
                        {
                            Console.WriteLine($"You gained {100 - energy} energy.");
                            Console.WriteLine($"Current energy: {100}.");
                        }

                        else
                        {
                            Console.WriteLine($"You gained {gainedEnergy} energy.");
                            Console.WriteLine($"Current energy: {energy + gainedEnergy}.");
                            energy += gainedEnergy;
                        }
                    }

                    else if (input[i] == "order")
                    {
                        if (energy >= 30)
                        {
                            coin += int.Parse(input[i + 1]);
                            Console.WriteLine($"You earned {input[i + 1]} coins.");
                            energy -= 30;
                        }

                        else
                        {
                            Console.WriteLine($"You had to rest!");
                            energy += 50;
                            if (energy > 100)
                            {
                                energy = 100;
                            }
                        }
                    }

                    else
                    {
                        if (int.Parse(input[i + 1]) < coin)
                        {
                            coin -= int.Parse(input[i + 1]);
                            Console.WriteLine($"You bought {input[i]}.");
                        }

                        else
                        {
                            Console.WriteLine($"Closed! Cannot afford {input[i]}.");
                            return;
                        }
                    }
                }
            }

            Console.WriteLine($"Day completed!");
            Console.WriteLine($"Coins: {coin}");
            Console.WriteLine($"Energy: {energy}");
        }
    }
}
