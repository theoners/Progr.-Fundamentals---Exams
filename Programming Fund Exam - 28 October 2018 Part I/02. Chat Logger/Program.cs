using System;
using System.Collections.Generic;

namespace _02._Chat_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = new List<string>();

            while (true)
            {
                var line = Console.ReadLine().Split();
                var command = line[0];
                if (command=="end")
                {
                    break;
                }

                switch (command)
                {
                    case "Chat":
                        message.Add(line[1]);
                        break;
                    case "Delete":
                    {
                        while(message.Contains(line[1]))
                        {
                            message.Remove(line[1]);
                        }

                        break;
                    }
                    case "Edit":
                    {
                        while (message.Contains(line[1]))
                        {
                            var index= message.IndexOf(line[1]);
                            message[index] = line[2];
                        }

                        break;
                    }
                    case "Pin":
                    {
                        if (message.Contains(line[1]))
                        {
                            message.Remove(line[1]);
                            message.Add(line[1]);
                        }

                        break;
                    }
                    case "Spam":
                    {
                        for (int i = 1; i < line.Length; i++)
                        {
                            message.Add(line[i]);
                        }

                        break;
                    }
                }
            }

            foreach (var word in message)
            {
                Console.WriteLine(word);
            }
        }
    }
}
