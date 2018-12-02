using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] {'|',':' }, StringSplitOptions.RemoveEmptyEntries);
            var words = Console.ReadLine().Split(" | ");
            string command = Console.ReadLine();
            var dictionary = new Dictionary<string, List<string>>();

            for (int i = 0; i < input.Length; i=i+2)
            {
                var word= input[i].Trim();

                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, new List<string>());
                }
                dictionary[word].Add(input[i + 1].Trim());
            }

            foreach (var word in dictionary.OrderBy(x=>x.Key.Length))
            {
                if (words.Contains(word.Key))
                {
                    Console.WriteLine(word.Key);
                    foreach (var discription in word.Value.OrderByDescending(x=>x.Length))
                    {
                        Console.WriteLine($" -{discription}");
                    }
                }
            }

            if (command=="End")
            {
                return;
            }
            else
            {
                foreach (var word in dictionary.OrderBy(x=>x.Key))
                {
                    Console.Write(word.Key+" ");
                }
            }
        }
    }
}
