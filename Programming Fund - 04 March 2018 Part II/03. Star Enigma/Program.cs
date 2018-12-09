using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Regex countLetter = new Regex(@"[starSTAR]");
            Regex regex = new Regex(@"@([a-zA-Z]+)[^@\-!:>]*:[0-9]+[^@\-!:>]*!(A|D)![^@\-!:>]*->[0-9]+");
            List<string> attackedPlanet = new List<string>();
            List<string> destroyedPlanet = new List<string>();

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();
                var matches = countLetter.Matches(input);
                int key = matches.Count;

                string decryptedMesage = decryptMesage(input, key);
                if (regex.IsMatch(decryptedMesage))
                {
                    var match = regex.Match(decryptedMesage);
                    string planetName = match.Groups[1].ToString();
                    string attackType = match.Groups[2].ToString();

                    if (attackType == "A")
                    {
                        attackedPlanet.Add(planetName);
                    }
                    else if (attackType == "D")
                    {
                        destroyedPlanet.Add(planetName);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanet.Count}");
            foreach (var planet in attackedPlanet.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanet.Count}");
            foreach (var planet in destroyedPlanet.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
        }

        private static string decryptMesage(string input, int key)
        {
            var result = "";
            for (int i = 0; i < input.Length; i++)
            {
                result += (char) (input[i] - key);
            }

            return result;
        }
    }
}