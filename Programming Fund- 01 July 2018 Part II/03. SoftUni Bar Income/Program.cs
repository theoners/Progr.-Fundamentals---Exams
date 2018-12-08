using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"%([A-Z][a-z]+)%.*?<(\w+)>.*?\|([0-9]+)\|.*?([0-9]+(\.[0-9]+)?)\$");
            var totalIncome = 0d;
            while (true)
            {
                string input = Console.ReadLine();
                if (input== "end of shift")
                {
                    break;
                }
                if (regex.IsMatch(input))
                {
                    var name = regex.Match(input).Groups[1].Value;
                    var product = regex.Match(input).Groups[2].Value;
                    var count = regex.Match(input).Groups[3].Value;
                    var price = regex.Match(input).Groups[4].Value;
                    var totalPrice = int.Parse(count) * double.Parse(price);

                    Console.WriteLine($"{name}: {product} - {totalPrice:F2}");
                    totalIncome += totalPrice;
                }
            }

            Console.WriteLine($"Total income: {totalIncome:F2}");
            
        }
    }
}
