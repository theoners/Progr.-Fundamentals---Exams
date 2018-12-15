namespace _04._Pokemon_Evolution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pokemon
    {
        public string EvolutionType { get; set; }
        public int EvolutionIndex { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var pokemonList = new Dictionary<string, List<Pokemon>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "wubbalubbadubdub")
                {
                    break;
                }

                if (input.Contains("->"))
                {
                    var inputSplit = input.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                    var name = inputSplit[0].Trim();
                    var type = inputSplit[1].Trim();
                    var index = int.Parse(inputSplit[2].Trim());

                    if (!pokemonList.ContainsKey(name))
                    {
                        pokemonList.Add(name, new List<Pokemon>());
                    }

                    var pokemon = new Pokemon()
                    {
                        EvolutionType = type,
                        EvolutionIndex = index
                    };
                    pokemonList[name].Add(pokemon);
                }
                else
                {
                    if (pokemonList.ContainsKey(input))
                    {
                        foreach (var pokemon in pokemonList.Where(x => x.Key == input))
                        {
                            Console.WriteLine($"# {pokemon.Key}");
                            foreach (var pokemonProperties in pokemon.Value)
                            {
                                Console.WriteLine($"{pokemonProperties.EvolutionType} <-> {pokemonProperties.EvolutionIndex}");
                            }
                        }
                    }
                }
            }

            foreach (var pokemon in pokemonList)
            {
                Console.WriteLine($"# {pokemon.Key}");
                foreach (var pokemonProperties in pokemon.Value.OrderByDescending(x => x.EvolutionIndex))
                {
                    Console.WriteLine($"{pokemonProperties.EvolutionType} <-> {pokemonProperties.EvolutionIndex}");
                }
            }
        }
    }
}
