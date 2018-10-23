using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Memory_View
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string codeAsText= "";
            while (input != "Visual Studio crash")
            {
                 codeAsText+= input;
                codeAsText += " ";
                input = Console.ReadLine();
            }
            if (codeAsText == "")
            {
                return;
            }
            codeAsText = codeAsText.Remove(codeAsText.Length - 1);
            List<char> name = new List<char>();
            List<int> code = codeAsText.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            while (code.Contains(32656))
            {
                int startIndex = code.IndexOf(32656);
                int letterCount = 0;
                if (code[startIndex+1]== 19759 && code[startIndex + 2]== 32763)
                {
                    letterCount = code[startIndex + 4];
                    for (int i = startIndex + 6; i < startIndex + 6 +letterCount; i++)
                    {
                        name.Add((char)code[i]);
                    }
                }
                for (int i = 0; i < name.Count; i++)
                {
                    Console.Write(name[i]);
                }
                Console.WriteLine();
                code.RemoveRange(startIndex, 6 + letterCount);
                name = new List<char>();
            }

            
        }
    }
}
