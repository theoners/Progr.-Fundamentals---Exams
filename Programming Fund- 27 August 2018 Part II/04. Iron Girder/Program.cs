using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Iron_Girder
{
    public class Track
    {
       public string TownName { get; set; }
        public int Time { get; set; }
        public int Passengers { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list = new Dictionary<string, Track>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line== "Slide rule")
                {
                    break;
                }
                var input = line.Split(new string[] {"->",":"}, StringSplitOptions.RemoveEmptyEntries);
                var town = input[0];
                var passengers = int.Parse(input[2]);
                if (input[1]=="ambush")
                {
                    if (list.ContainsKey(town))
                    {
                        list[town].Time = 0;
                        list[town].Passengers -= passengers;
                        if (list[town].Passengers<0)
                        {
                            list[town].Passengers = 0;
                        }
                    }
                }
                else
                {
                    var time = int.Parse(input[1]);


                    if (!list.ContainsKey(town))
                    {
                        var track = new Track()
                        {
                            TownName = town,
                            Time = time,
                            Passengers = passengers
                        };

                        list.Add(town, track);
                    }
                    else
                    {
                        if (list[town].Time > time)
                        {
                            list[town].Time = time;
                        }
                        else if(list[town].Time==0)
                        {
                            list[town].Time = time;
                        }

                        list[town].Passengers += passengers;
                    }
                }
            }

            foreach (var kvp in list.OrderBy(t=>t.Value.Time).ThenBy(x=>x.Value.TownName))
            {
                if (kvp.Value.Time!=0 && kvp.Value.Passengers!=0)
                {
                    Console.WriteLine($"{kvp.Value.TownName} -> Time: {kvp.Value.Time} -> Passengers: {kvp.Value.Passengers}");
                }
            }
        }

    }
}
