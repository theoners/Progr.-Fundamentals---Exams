using System;
using System.Text.RegularExpressions;

namespace _03._Regexmon
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex didimonRegex = new Regex(@"[^A-Za-z-]+");
            Regex bojomonRegex = new Regex(@"[A-Za-z]+-[a-zA-Z]+");

            while (input.Length!=0)
            {
                var didimon = didimonRegex.Match(input).Value;
                if (!didimonRegex.IsMatch(input))
                {
                    break;
                }
                Console.WriteLine(didimon);
                var index = input.IndexOf(didimon);
                input = input.Remove(0, index + didimon.Length);
                var bojomon = bojomonRegex.Match(input).Value;
                if (!bojomonRegex.IsMatch(input))
                {
                    break;
                }
                Console.WriteLine(bojomon);
                index = input.IndexOf(bojomon);
                input = input.Remove(0, index + bojomon.Length);
            }
        }
    }
}
