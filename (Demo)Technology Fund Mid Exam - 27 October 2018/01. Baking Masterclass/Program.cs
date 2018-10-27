using System;

namespace _01._Baking_Masterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double students = int.Parse(Console.ReadLine());
            double priceOfFlour = double.Parse(Console.ReadLine());
            double priceOfegg = double.Parse(Console.ReadLine());
            double priceOfApron = double.Parse(Console.ReadLine());

            int freeFlour = (int)students / 5;

            double priceOfNeededItems = (priceOfApron * Math.Ceiling(students * 1.2))
                                        + priceOfegg * 10 * students + priceOfFlour * (students - freeFlour);

            if (budget >= priceOfNeededItems)
            {
                Console.WriteLine($"Items purchased for {(priceOfNeededItems):F2}$.");
            }

            else
            {
                Console.WriteLine($"{(priceOfNeededItems - budget):F2}$ more needed.");
            }
        }
    }
}
