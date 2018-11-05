using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Quests_Journal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();
            string questWithSideQuest = "";

            while (input!= "Retire!")
            {
                string[] command = input.Split(new string[] { " - ", ":" }, StringSplitOptions.RemoveEmptyEntries);

                if (command[0]== "Start")
                {
                    if (!journal.Contains(command[1]))
                    {
                        journal.Add(command[1]);
                    }
                }
                else if(command[0] == "Complete")
                {
                    if (journal.Contains(command[1]))
                    {
                        journal.Remove(command[1]);
                    }
                }
                else if (command[0] == "Side Quest")
                {
                    
                    if (journal.Contains(command[1]) && !questWithSideQuest.Contains(command[1]))
                    { 
                        int index = journal.IndexOf(command[1]);
                        if (index!=journal.Count-1 )
                        {
                            if (journal[index + 1]!=command[2])
                            {
                                journal.Insert(index + 1, command[2]);
                                questWithSideQuest += command[1] + " ";
                            }
                        }
                        else 
                        {
                            journal.Add(command[2]);
                            questWithSideQuest += command[1] + " ";
                        }
                       
                    }
                   
                }
                else if (command[0] == "Renew")
                {
                    if (journal.Contains(command[1]))
                    {
                        journal.Remove(command[1]);
                        journal.Add(command[1]);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ",journal));
        }
    }
}
