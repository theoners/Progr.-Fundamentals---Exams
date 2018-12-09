using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var forceBook = new Dictionary<string, List<string>>();
            while (text != "Lumpawaroo")
            {
                bool isContains = false;
                if (text.Contains(" | "))
                {
                    string[] input = text.Split(new string[] {" | "}, StringSplitOptions.RemoveEmptyEntries);
                    string forceUser = input[1];
                    string forceSide = input[0];
                    if (!forceBook.ContainsKey(forceSide))
                    {
                        forceBook.Add(forceSide, new List<string>());
                    }

                    foreach (var values in forceBook)
                    {
                        if (values.Value.Contains(forceUser))
                        {
                            isContains = true;
                            break;
                        }
                    }

                    if (!isContains)
                    {
                        forceBook[forceSide].Add(forceUser);
                    }
                }
                else if (text.Contains(" -> "))
                {
                    string[] input = text.Split(new string[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                    string forceUser = input[0];
                    string forceSide = input[1];

                    foreach (var values in forceBook)
                    {
                        if (values.Value.Contains(forceUser))
                        {
                            forceBook[values.Key].Remove(forceUser);
                            break;
                        }
                    }

                    if (!forceBook.ContainsKey(forceSide))
                    {
                        forceBook.Add(forceSide, new List<string>());
                    }

                    forceBook[forceSide].Add(forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

                text = Console.ReadLine();
            }

            forceBook = forceBook.Where(x => x.Value.Count > 0).ToDictionary(x => x.Key, y => y.Value);

            foreach (var kvp in forceBook.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                foreach (var user in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}