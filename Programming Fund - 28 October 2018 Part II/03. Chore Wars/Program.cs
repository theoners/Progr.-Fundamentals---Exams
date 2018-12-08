using System;
using System.Text.RegularExpressions;

namespace _03._Chore_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            var dishesRegex = new Regex(@"<[a-z0-9]+>");
            var houseRegex = new Regex(@"\[[A-Z0-9]+\]");
            var laundryRegex = new Regex(@"\{.+\}");
            var doingTheDishesTime = 0;
            var cleaningTheHouseTime = 0;
            var doingTheLaundryTime = 0;

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "wife is happy")
                {
                    break;
                }

                if (dishesRegex.IsMatch(input))
                {
                    var firstMatches = dishesRegex.Matches(input);
                    var currentTime = CountTime(firstMatches);
                    doingTheDishesTime += currentTime;
                }

                if (houseRegex.IsMatch(input))
                {
                    var secondMatches = houseRegex.Matches(input);
                    var currentTime = CountTime(secondMatches);
                    cleaningTheHouseTime += currentTime;
                }

                if (laundryRegex.IsMatch(input))
                {
                    var thirdMatches = laundryRegex.Matches(input);
                    var currentTime = CountTime(thirdMatches);
                    doingTheLaundryTime += currentTime;
                }
            }

            Console.WriteLine($"Doing the dishes - {doingTheDishesTime} min.");
            Console.WriteLine($"Cleaning the house - {cleaningTheHouseTime} min.");
            Console.WriteLine($"Doing the laundry - {doingTheLaundryTime} min.");
            Console.WriteLine($"Total - {doingTheLaundryTime + doingTheDishesTime + cleaningTheHouseTime} min.");
        }

        private static int CountTime(MatchCollection firstMatches)
        {
            var time = 0;

            foreach (Match match in firstMatches)
            {
                var currentMatch = match.ToString();
                for (int i = 0; i < currentMatch.Length; i++)
                {
                    if (char.IsDigit(currentMatch[i]))
                    {
                        time += currentMatch[i]-48;
                    }
                }
            }
            return time;
        }
    }
}
