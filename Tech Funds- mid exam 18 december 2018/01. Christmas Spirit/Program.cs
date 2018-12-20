using System;

namespace _01._Christmas_Spirit
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int ornamentSet = 2;
            int threeSkirt = 5;
            int treeGerlands = 3;
            int treeLight = 15;
            int totalCost = 0;
            int totalSpirit = 0;

            for (int i = 1; i <= days; i++)
            {
                if (i%11==0)
                {
                    quantity += 2;
                }
                if (i%2==0)
                {
                    totalCost += ornamentSet*quantity;
                    totalSpirit += 5;
                }
                 if (i%3==0)
                {
                    totalCost += threeSkirt * quantity + treeGerlands * quantity;
                    totalSpirit += 13;
                }
                 if (i%5==0)
                {
                    totalCost += treeLight * quantity;
                    totalSpirit += 17;
                    if (i%3==0)
                    {
                        totalSpirit += 30;
                    }
                }
                 if (i%10==0)
                {
                    totalSpirit -= 20;
                    totalCost += threeSkirt + treeGerlands + treeLight;
                }

             
            }
            if (days%10==0)
            {
                totalSpirit -= 30;
            }

            Console.WriteLine($"Total cost: {totalCost}");
            Console.WriteLine($"Total spirit: {totalSpirit}");
        }
    }
}
