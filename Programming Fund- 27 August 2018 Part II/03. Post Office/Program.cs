using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Post_Office
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split('|');
            var firstPart = input[0];
            var secondPart = input[1];
            var wordList = input[2].Split();
            var  result = new List<string>();

            Regex firstPartRegex = new Regex(@"([#$%*&])([A-Z]+)\1");
            Regex secondPartRegex = new Regex(@"([6-9][0-9]):([0-9]{2,})");
            var letters = firstPartRegex.Match(firstPart).ToString();
            var wordLeght = secondPartRegex.Matches(secondPart);
            foreach (Match count in wordLeght)
            {
                var letter = (char)(int.Parse(count.Groups[1].ToString()));
                if (letters.Contains(letter))
                {
                    for (int i = 0; i < wordList.Length; i++)
                    {
                        if (wordList[i][0]==letter)
                        {
                            if (wordList[i].Length ==1+int.Parse(count.Groups[2].ToString()))
                            {
                                if (!result.Contains(wordList[i]))
                                {
                                    result.Add(wordList[i]);
                                }
                            }
                            
                        }
                    }
                }
            }

            for (int i = 1; i < letters.Length-1; i++)
            {
                for (int j = 0; j < result.Count; j++)
                {
                    if (result[j][0]==letters[i])
                    {
                        Console.WriteLine(result[j]);
                    }
                }
            }
        }
    }
}
