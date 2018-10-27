using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Baking_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> breadNumbersAndQuality = new List<int>();
            int breadQuality = int.MinValue;
            double avarageQuality = int.MinValue;
            List<int> bestBread = new List<int>();

            while (input != "Bake It!")
            {
                breadNumbersAndQuality = input
                                         .Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse).ToList();
                if (breadNumbersAndQuality.Sum() > breadQuality)
                {
                    bestBread = breadNumbersAndQuality;
                    avarageQuality = 1.0 * bestBread.Sum() / bestBread.Count;
                    breadQuality = breadNumbersAndQuality.Sum();
                }
                else if (breadNumbersAndQuality.Sum() == breadQuality)
                {
                    double currentAvaregeQuality = 1.0 * breadNumbersAndQuality.Sum() / breadNumbersAndQuality.Count;
                    if (currentAvaregeQuality > avarageQuality)
                    {
                        bestBread = breadNumbersAndQuality;
                        avarageQuality = currentAvaregeQuality;
                        breadQuality = bestBread.Sum();
                    }
                    else if (currentAvaregeQuality == avarageQuality)
                    {
                        if (breadNumbersAndQuality.Count < bestBread.Count)
                        {
                            bestBread = breadNumbersAndQuality;
                            avarageQuality = currentAvaregeQuality;
                            breadQuality = bestBread.Sum();
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Best Batch quality: {bestBread.Sum()}");
            Console.WriteLine(string.Join(' ', bestBread));
        }
    }
}
