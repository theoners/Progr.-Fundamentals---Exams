using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Snowmen
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> snowmen = Console.ReadLine()
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToList();

            List<int> loserList = new List<int>();
            while (snowmen.Count != 1)
            {
                for (int index = 0; index < snowmen.Count; index++)
                {
                    if (Math.Abs(loserList.Count - snowmen.Count) == 1)
                    {
                        continue;
                    }

                    if (loserList.Contains(index))
                    {
                        continue;
                    }

                    int attackerIndex = index;
                    int targteIndex = ValidIndex(snowmen[attackerIndex], snowmen.Count);
                    int absoluteValue = Math.Abs(attackerIndex - targteIndex);

                    if (absoluteValue == 0)
                    {
                        Console.WriteLine($"{attackerIndex} performed harakiri");
                        loserList.Add(attackerIndex);
                        loserList = loserList.Distinct().ToList();
                    }

                    else if (absoluteValue % 2 == 0)
                    {
                        Console.WriteLine($"{attackerIndex} x {targteIndex} -> {attackerIndex} wins");
                        loserList.Add(targteIndex);
                        loserList = loserList.Distinct().ToList();
                    }

                    else
                    {
                        Console.WriteLine($"{attackerIndex} x {targteIndex} -> {targteIndex} wins");
                        loserList.Add(attackerIndex);
                        loserList = loserList.Distinct().ToList();
                    }
                }

                foreach (var index in loserList.OrderByDescending(x => x).Distinct())
                {
                    snowmen.RemoveAt(index);
                }

                loserList.Clear();
            }
        }
        private static int ValidIndex(int index, int lenght)
        {
            if (index >= lenght)
            {
                index = index % lenght;
            }
            return index;
        }
    }
}