using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hornet_Armada
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var legions = new Dictionary<string,Dictionary<string,long>>();
            var activities = new Dictionary<string,long>();
            int lineNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < lineNumber; i++)
            {
                var input = Console.ReadLine().Split(new[] { '=', '-', '>', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var activity = long.Parse(input[0].Trim());
                var legionName = input[1].Trim();
                var soldierType = input[2].Trim();
                var soldierCounts = long.Parse(input[3].Trim());
                if (!legions.ContainsKey(legionName))
                {
                    legions.Add(legionName, new Dictionary<string, long>());
                    activities.Add(legionName,activity);
                }

                if (!legions[legionName].ContainsKey(soldierType))
                {
                    legions[legionName].Add(soldierType,0);
                }
               
                    legions[legionName][soldierType] += soldierCounts;

                if (activities[legionName]<activity)
                {
                    activities[legionName] = activity;
                }
            }
            string[] commands = Console.ReadLine().Split('\\');

            if (commands.Length == 1)
            {
                string soldType = commands[0];
                foreach (var legion in activities.OrderByDescending(l => l.Value))
                {
                    if (legions[legion.Key].ContainsKey(soldType))
                    {
                        Console.WriteLine($"{legion.Value} : {legion.Key}");
                    }
                }
            }
            else
            {
                int searchedActivity = int.Parse(commands[0]);
                string type = commands[1];

                foreach (var legion in legions.Where(l => l.Value.ContainsKey(type))
                    .OrderByDescending(l => l.Value[type]))
                {
                    if (activities[legion.Key] < searchedActivity)
                    {
                        Console.WriteLine($"{legion.Key} -> {legion.Value[type]}");
                    }
                }
            }
        }
    }
}
    

