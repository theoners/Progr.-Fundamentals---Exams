using System;
using System.Linq;

namespace _03._Hornet_Assault
{
    class Program
    {
        static void Main(string[] args)
        {
            var beehives = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            var hornets = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            long hornetsSum = hornets.Sum();
            for (int i = 0; i < beehives.Length; i++)
            {
                if (beehives[i] < hornetsSum)
                {
                    beehives[i] = 0;
                }
                else
                {
                    
                    if (hornets.Count>0)
                    {
                        beehives[i] -= hornetsSum;
                        hornets.RemoveAt(0);
                        hornetsSum = hornets.Sum();
                    }
                    else
                    {
                        break;
                    }

                }
            }

            if (beehives.Sum() > 0)
            {
                Console.WriteLine(string.Join(" ", beehives.Where(x => x > 0)));
            }
            else
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
        }
    }
}
