using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Tseam_Account
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> gameCollections = Console.ReadLine().Split(' ').ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Play!")
                {
                    break;
                }


                var commands = line.Split(' ');
                var command = commands[0];
                var gameName = commands[1];
                if (command == "Install")
                {
                    if (!gameCollections.Contains(gameName))
                    {
                        gameCollections.Add(gameName);
                    }

                }
                else if (command == "Uninstall")
                {
                    if (gameCollections.Contains(gameName))
                    {
                        gameCollections.Remove(gameName);
                    }
                }
                else if (command == "Update")
                {
                    if (gameCollections.Contains(gameName))
                    {
                        gameCollections.Remove(gameName);
                        gameCollections.Add(gameName);
                    }
                }
                else if (command == "Expansion")
                {
                    var name = gameName.Split('-')[0];
                    var expansion = gameName.Split('-')[1];
                    if (gameCollections.Contains(name))
                    {

                        var index = gameCollections.IndexOf(name);
                        gameCollections.Insert(index + 1, name+':'+expansion);
                    }
                }


            }

            Console.WriteLine(string.Join(" ", gameCollections));
        }
    }
}
