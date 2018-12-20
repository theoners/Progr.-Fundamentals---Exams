using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Santa_s_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> kids = Console.ReadLine().Split('&').ToList();

            while (true)
            {
                var command = Console.ReadLine().Split();
                if (command[0]== "Finished!")
                {
                    break;
                }

                if (command[0]=="Bad")
                {
                    var kid = command[1];
                    if (!kids.Contains(kid))
                    {
                        kids.Insert(0,kid);
                    }
                   
                }
                else if (command[0] == "Good")
                {
                    var kid = command[1];
                    if (kids.Contains(kid))
                    {
                        kids.Remove(kid);
                    }
                }
                else if(command[0]=="Rename")
                {
                    var oldName = command[1];
                    var newName = command[2];
                    if (kids.Contains(oldName))
                    {
                        var index = kids.IndexOf(oldName);
                        kids[index] = newName;
                    }
                }
                else if (command[0]== "Rearrange")
                {
                    var kid = command[1];
                    if (kids.Contains(kid))
                    {
                        kids.Remove(kid);
                        kids.Add(kid);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", kids));
        }
    }
}
