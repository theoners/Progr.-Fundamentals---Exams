using System;
using System.Numerics;

namespace _01._Anonymous_Downsite
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfWebSite = int.Parse(Console.ReadLine());
            var securityKey = BigInteger.Parse(Console.ReadLine());
            decimal totalLoss = 0;
            for (int i = 0; i < numberOfWebSite; i++)
            {
                var data = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);

                var siteName = data[0].Trim();
                var siteVisits = long.Parse(data[1].Trim());
                var siteCommercialPricePerVisit = decimal.Parse(data[2].Trim());

                Console.WriteLine(siteName);
                totalLoss += siteCommercialPricePerVisit * siteVisits;
            }

            var  securityTokens = BigInteger.Pow(securityKey, numberOfWebSite);

            Console.WriteLine($"Total Loss: {totalLoss:F20}");
            
            Console.WriteLine($"Security Token: {securityTokens}");
        }
    }
}
