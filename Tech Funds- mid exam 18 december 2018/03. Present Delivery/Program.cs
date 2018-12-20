using System;
using System.Linq;

namespace _03._Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            var houseMembers = Console.ReadLine().Split('@').Select(int.Parse).ToArray();
            var currentIndex = 0;
            while (true)
            {
                var command = Console.ReadLine().Split();
                if (command[0]== "Merry")
                {
                    break;
                }

                var jumpLenght = int.Parse(command[1]);
                
                if (houseMembers[(currentIndex+jumpLenght)%houseMembers.Length]==0)
                {
                    Console.WriteLine($"House {(currentIndex + jumpLenght) % houseMembers.Length} will have a Merry Christmas.");
                    currentIndex = (currentIndex + jumpLenght) % houseMembers.Length;
                }else
                {
                    houseMembers[(currentIndex + jumpLenght )% houseMembers.Length] -= 2;
                    
                    if (houseMembers[(currentIndex + jumpLenght) % houseMembers.Length]<0)
                    {
                        houseMembers[(currentIndex + jumpLenght) % houseMembers.Length] = 0;
                    }
                    currentIndex = (currentIndex + jumpLenght) % houseMembers.Length;
                }
            }

            var count = 0;
            for (int i = 0; i < houseMembers.Length; i++)
            {
                if (houseMembers[i]!=0)
                {
                    count++;
                }
            }
            Console.WriteLine($"Santa's last position was {currentIndex}.");
            if (count==0)
            {
                Console.WriteLine($"Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Santa has failed {count} houses.");
            }
            
        }
    }
}
