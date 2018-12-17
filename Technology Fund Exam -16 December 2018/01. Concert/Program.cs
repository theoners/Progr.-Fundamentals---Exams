using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> bandList = new Dictionary<string, List<string>>();
            Dictionary<string, long> playTimes = new Dictionary<string, long>();
            while (true)
            {
                var input = Console.ReadLine().Split(new string[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "start of concert")
                {
                    break;
                }

                var command = input[0].Trim();
                if (command == "Add")
                {

                    var bandName = input[1].Trim();
                    if (!bandList.ContainsKey(bandName))
                    {
                        bandList.Add(bandName, new List<string>());

                    }

                    for (int i = 2; i < input.Length; i++)
                    {
                        var member = input[i].Trim();
                        if (!bandList[bandName].Contains(member))
                        {
                            bandList[bandName].Add(member);
                        }
                    }
                }
                else
                {
                    var bandName = input[1].Trim();
                    var playTime = long.Parse(input[2].Trim());

                    if (!playTimes.ContainsKey(bandName))
                    {
                        playTimes.Add(bandName,0);
                    }

                    playTimes[bandName] += playTime;
                }

            }

            var groupName = Console.ReadLine();

            Console.WriteLine($"Total time: {playTimes.Values.Sum()}");
            foreach (var kvp in playTimes.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            foreach (var band in bandList.Where(x=>x.Key==groupName))
            {
                Console.WriteLine(band.Key);
                foreach (var member in band.Value)
                {
                    Console.WriteLine($"=> {member}");
                }
            }
        }
    }
}
