namespace _03._Anonymous_Vox
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string value = Console.ReadLine();
            Regex textRegex = new Regex(@"([A-Za-z]+)(.+)\1");
            Regex valueRegex = new Regex(@"{(.+?)}");
            List<string> wordList = new List<string>();
            List<string> valueList = new List<string>();

            var placeHolders = textRegex.Matches(text);
            var values = valueRegex.Matches(value);

            if (!textRegex.IsMatch(text) && valueRegex.IsMatch(value))
            {
                Console.WriteLine(text);
                return;
            }
            foreach (Match placeHolder in placeHolders)
            {
                wordList.Add(placeHolder.Groups[2].Value);
            }

            foreach (Match valueWord in values)
            {
                valueList.Add(valueWord.Groups[1].Value);
            }

            var count = Math.Min(wordList.Count, valueList.Count);

            for (int i = 0; i < count; i++)
            {
                var index = text.IndexOf(wordList[i]);
                text = text.Remove(index, wordList[i].Length);
                text = text.Insert(index, valueList[i]);
            }

            Console.WriteLine(text);
        }
    }
}
