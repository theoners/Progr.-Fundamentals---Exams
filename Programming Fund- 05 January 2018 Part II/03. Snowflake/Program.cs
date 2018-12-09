using System;
using System.Text.RegularExpressions;

namespace _03._Snowflake
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regexSurface = new Regex(@"[^A-Za-z0-9]+");
            Regex regexMantle = new Regex(@"[0-9_]+");
            Regex allRegex = new Regex(@"([^A-Za-z0-9]+)([0-9_]+)([A-Za-z]+)([0-9_]+)([^A-Za-z0-9]+)");

            var firstLine = Console.ReadLine();
            var secondLine = Console.ReadLine();
            var thirdLine = Console.ReadLine();
            var fourthLine = Console.ReadLine();
            var fifthLine = Console.ReadLine();

            var firstMatch = regexSurface.Match(firstLine);
            var secondMatch = regexMantle.Match(secondLine);
            var thirdMatch = allRegex.Match(thirdLine);
            var fourthMatch = regexMantle.Match(fourthLine);
            var fifthMatch = regexSurface.Match(fifthLine);
            if (firstMatch.Value == firstLine && secondLine == secondMatch.Value &&
                thirdLine == thirdMatch.Value && fourthLine == fourthMatch.Value &&
                fifthMatch.Value == fifthLine)
            {
                var coreLength = allRegex.Match(thirdLine).Groups[3].Value.Length;
                Console.WriteLine("Valid");
                Console.WriteLine(coreLength);
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}
