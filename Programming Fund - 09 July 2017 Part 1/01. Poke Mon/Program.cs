using System;
using System.Numerics;

namespace _01._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int pokedTarget = 0;
            BigInteger tempN = n;

            while (n >= m)
            {
                n = n - m;
                pokedTarget++;
                if (tempN - n == n)
                {
                    if (y != 0)
                    {
                        n = n / y;
                    }

                }
            }

            Console.WriteLine($"{n}");
            Console.WriteLine($"{pokedTarget}");
        }
    }
}
