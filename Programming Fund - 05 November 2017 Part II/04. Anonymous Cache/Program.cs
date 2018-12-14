using System.Linq;
using System.Text.RegularExpressions;

namespace _04._Anonymous_Cache
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList= new List<string>();
            var dataSets = new Dictionary<string, Dictionary<string, long>>();
            List<string> dataKeys = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "thetinggoesskrra")
                {
                    break;
                }
                inputList.Add(input);
            }

            for (int i = 0; i < inputList.Count; i++)
            {
                if (!inputList[i].Contains("->"))
                {
                    dataSets.Add(inputList[i],new Dictionary<string, long>());
                    
                }
                else
                {
                    dataKeys.Add(inputList[i]);
                }
            }

            for (int i = 0; i < dataKeys.Count; i++)
            {
                var dataKeySplit = dataKeys[i].Split(new string[] {"->", "|"}, StringSplitOptions.RemoveEmptyEntries);
                var dataKey = dataKeySplit[0].Trim();
                var dataSize = long.Parse(dataKeySplit[1].Trim());
                var dataSet = dataKeySplit[2].Trim();

                if (dataSets.ContainsKey(dataSet))
                {
                    dataSets[dataSet].Add(dataKey,dataSize);
                }
            }

            foreach (var dataSet in dataSets.OrderByDescending(x=>x.Value.Values.Sum()))
            {
                Console.WriteLine($"Data Set: {dataSet.Key}, Total Size: {dataSet.Value.Values.Sum()}");
                foreach (var dataKey in dataSet.Value)
                {
                    Console.WriteLine($"$.{dataKey.Key}");
                }
               break;
            }
        }
    }
}
