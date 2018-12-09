using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            var dwarfsList = new Dictionary<string, int>();
            string input = Console.ReadLine();
            while (input != "Once upon a time")
            {
                string[] inputs = input.Split(new string[] { " <:> " }, StringSplitOptions.None);
                string name = inputs[0];
                string color = inputs[1];
                int physics = int.Parse(inputs[2]);

                string nameAndHatColor = name + ">" + color;
                if (!dwarfsList.ContainsKey(nameAndHatColor))
                {
                    dwarfsList.Add(nameAndHatColor, physics);
                }
                else
                {
                    if (dwarfsList[nameAndHatColor] < physics)
                    {
                        dwarfsList[nameAndHatColor] = physics;
                    }
                }

                input = Console.ReadLine();
            }
            foreach (var dwarf in dwarfsList.OrderByDescending(x => x.Value)
                .ThenByDescending(x => dwarfsList.Count(y => y.Key.Split('>')[1] == x.Key.Split('>')[1])))
            {
                Console.WriteLine($"({dwarf.Key.Split('>')[1]}) {dwarf.Key.Split('>')[0]} <-> {dwarf.Value}");
            }
        }
    }
}
