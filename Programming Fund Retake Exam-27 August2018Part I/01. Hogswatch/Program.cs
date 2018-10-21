using System;

namespace _01._Hogswatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int homesToVisit = int.Parse(Console.ReadLine());
            int numberOfPresents = int.Parse(Console.ReadLine());
            int totalPresents = numberOfPresents;
            int visitedHome = 0;
            int timesBack = 0;
            int retakeNumberOfPresents = 0;

            for (int i = 0; i < homesToVisit; i++)
            {
                int numberOfChildren = int.Parse(Console.ReadLine());
                if (numberOfChildren<=numberOfPresents)
                {
                    visitedHome++;
                    numberOfPresents -= numberOfChildren;
                }
                else
                {
                    visitedHome++;
                    int presentsNeed=((totalPresents / visitedHome) * (homesToVisit-visitedHome) 
                                                + (numberOfChildren-numberOfPresents));
                    retakeNumberOfPresents += presentsNeed;
                    numberOfPresents += presentsNeed;
                    numberOfPresents -= numberOfChildren;
                    timesBack++;
                }
                
            }

            if (timesBack==0)
            {
                Console.WriteLine(numberOfPresents);
            }
            else
            {
                Console.WriteLine(timesBack);
                Console.WriteLine(retakeNumberOfPresents);
            }
        }
    }
}
