using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Grains_of_Sands
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> grainOfSands = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split();

            while (command[0]!="Mort")
            {
                if (command[0]=="Add")
                {
                    grainOfSands.Add(int.Parse(command[1]));
                }
                else if (command[0] == "Remove")
                {
                   bool isRomeve= grainOfSands.Remove(int.Parse(command[1]));

                    if (!isRomeve)
                    {
                        if (int.Parse(command[1])<grainOfSands.Count)
                        {
                            grainOfSands.RemoveAt(int.Parse(command[1]));
                        }
                    }

                }
                else if (command[0] == "Replace")
                {
                    if (grainOfSands.Contains(int.Parse(command[1])))
                    {
                        int index =grainOfSands.IndexOf(int.Parse(command[1]));
                        grainOfSands[index] = int.Parse(command[2]);
                    }
                }
                else if (command[0] == "Increase")
                {
                    int greaterValue=int.MinValue;

                    foreach (var sands in grainOfSands)
                    {
                        if (sands >= int.Parse(command[1]))
                        {
                            greaterValue = sands;
                            break;
                        }
                    }

                    if (greaterValue!=int.MinValue)
                    {
                        for (int i = 0; i < grainOfSands.Count; i++)
                        {
                            grainOfSands[i] = grainOfSands[i] + greaterValue;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < grainOfSands.Count; i++)
                        {
                            grainOfSands[i] = grainOfSands[i] + grainOfSands[grainOfSands.Count-1];
                        }
                    }
                }
                else if (command[0] == "Collapse")
                {
                    for (int i = 0; i < grainOfSands.Count; i++)
                    {
                        if (grainOfSands[i]<int.Parse(command[1]))
                        {
                            grainOfSands.RemoveAt(i);
                            i--;
                        }
                    }
                }
                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ",grainOfSands));
        }
    }
}
