using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            var pokemonDistances = Console.ReadLine()
                                  .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToList();
            int index = int.Parse(Console.ReadLine());
            int removedsElementsSum = 0;

            while (true)
            {
                if (index >= 0 && index < pokemonDistances.Count)
                {
                    removedsElementsSum += pokemonDistances[index];
                    RemoveElements(pokemonDistances, index);
                }

                else if (index < 0)
                {
                    removedsElementsSum += pokemonDistances[0];
                    RemoveElements(pokemonDistances, 0);
                    pokemonDistances.Insert(0, pokemonDistances[pokemonDistances.Count - 1]);
                }
                else if (index >= pokemonDistances.Count)
                {
                    removedsElementsSum += pokemonDistances[pokemonDistances.Count - 1];
                    RemoveElements(pokemonDistances, pokemonDistances.Count - 1);
                    pokemonDistances.Add(pokemonDistances[0]);
                }

                if (pokemonDistances.Count != 0)
                {
                    index = int.Parse(Console.ReadLine());
                }
                else
                {
                    break;
                }

            }

            Console.WriteLine(removedsElementsSum);
        }

        private static void RemoveElements(List<int> pokemonDistances, int index)
        {
            int currentPokemon = pokemonDistances[index];
            for (int i = 0; i < pokemonDistances.Count; i++)
            {
                if (pokemonDistances[i] > currentPokemon)
                {
                    pokemonDistances[i] -= currentPokemon;
                }
                else
                {
                    pokemonDistances[i] += currentPokemon;
                }
            }

            pokemonDistances.RemoveAt(index);
        }
    }
}
