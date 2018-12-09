using System;
using System.Numerics;

namespace _01._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int snowballsNumber = int.Parse(Console.ReadLine());
            int snowballSnow = 0;
            int snowballTime = 0;
            int snowballQuality = 0;
            int snowballSnowMax = 0;
            int snowballTimeMax = 0;
            int snowballQualityMax = 0;
            BigInteger SnowballValue = 0;
            BigInteger SnowballValueMax = 0;
            for (int i = 0; i < snowballsNumber; i++)
            {
                snowballSnow = int.Parse(Console.ReadLine());
                snowballTime = int.Parse(Console.ReadLine());
                snowballQuality = int.Parse(Console.ReadLine());
                SnowballValue = snowballSnow / snowballTime;
                SnowballValue = BigInteger.Pow(SnowballValue, snowballQuality);

                if (SnowballValue > SnowballValueMax)
                {
                    snowballSnowMax = snowballSnow;
                    snowballTimeMax = snowballTime;
                    snowballQualityMax = snowballQuality;
                    SnowballValueMax = SnowballValue;
                }
            }
            Console.WriteLine($"{snowballSnowMax} : {snowballTimeMax} = {SnowballValueMax} ({snowballQualityMax})");
        }
    }
}
