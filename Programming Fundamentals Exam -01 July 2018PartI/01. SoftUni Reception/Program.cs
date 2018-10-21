using System;

namespace _01._SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            int totalEfficiency = firstEmployeeEfficiency + secondEmployeeEfficiency + thirdEmployeeEfficiency;
            int timeNeed = 0;

            while (students>0)
            {
                students -= totalEfficiency;
                timeNeed++;
            }
            if (timeNeed%3==0 && timeNeed!=0)
            {
                timeNeed += (timeNeed / 3)-1;
            }
            else
            {
                timeNeed += timeNeed / 3;
            }
           

            Console.WriteLine($"Time needed: {timeNeed}h.");

        }
    }
}
