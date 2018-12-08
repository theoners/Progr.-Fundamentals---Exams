namespace _01._Google_Searches
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var totalDays = int.Parse(Console.ReadLine());
            var numberOfUsers = int.Parse(Console.ReadLine());
            var moneyPerSearch = double.Parse(Console.ReadLine());
            var totalMoneyEarned = 0d;

            for (int i = 1; i <= numberOfUsers; i++)
            {
                var currentWordLength = double.Parse(Console.ReadLine());

                if (currentWordLength <= 5 && currentWordLength != 1 && i % 3 != 0)
                {
                    totalMoneyEarned += moneyPerSearch;
                }
                else if (currentWordLength == 1 && i % 3 != 0)
                {
                    totalMoneyEarned += moneyPerSearch * 2;
                }

                else if (i % 3 == 0 && currentWordLength <= 5&& currentWordLength!=1)
                {
                    totalMoneyEarned += moneyPerSearch * 3;
                }
                else if (currentWordLength == 1 && i % 3 == 0)
                {
                    totalMoneyEarned += moneyPerSearch * 6;
                }

            }

            totalMoneyEarned *= totalDays;

            Console.WriteLine($"Total money earned for {totalDays} days: {totalMoneyEarned:F2}");
        }
    }
}
