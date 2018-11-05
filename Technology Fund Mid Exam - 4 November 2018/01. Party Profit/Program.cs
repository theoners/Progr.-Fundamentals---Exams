using System;

namespace _01._Party_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int partySize = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            double coins = 0;
            int companions = partySize;

            for (int i = 1; i <= days; i++)
            {
                if (i%10==0)
                {
                    companions -= 2;
                }
                if (i%15==0)
                {
                    companions += 5;
                }
                coins += 50;
                coins -= companions * 2;

                if (i%3==0)
                {
                    coins -= companions * 3;
                }

                if (i%5==0)
                {
                    coins += companions * 20;
                    if (i%5==0&& i%3==0)
                    {
                        coins -= companions * 2;
                    }
                }
            }
            coins = Math.Floor(coins / companions);
            Console.WriteLine($"{companions} companions received {coins} coins each.");
        }
    }
}
