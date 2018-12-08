using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var results = new Dictionary<string, int>();
            var submissionsCount = new Dictionary<string, int>();
            var bannedList = new List<string>();

            while (input != "exam finished")
            {
                string[] line = input.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                if (!input.Contains("banned"))
                {
                    string name = line[0];
                    string language = line[1];
                    int points = int.Parse(line[2]);

                    if (!results.ContainsKey(name) && !bannedList.Contains(name))
                    {
                        results.Add(name, points);
                    }
                    else if (!bannedList.Contains(name))
                    {
                        if (results[name] < points)
                        {
                            results[name] = points;
                        }
                    }

                    if (!submissionsCount.ContainsKey(language) && !bannedList.Contains(name))
                    {
                        submissionsCount.Add(language, 1);
                    }
                    else if (!bannedList.Contains(name))
                    {
                        submissionsCount[language]++;
                    }
                }

                else
                {
                    string name = line[0];
                    results.Remove(name);
                    bannedList.Add(name);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");

            foreach (var result in results.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{result.Key} | {result.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var submission in submissionsCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
