using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialLessons = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None).ToList();
            string input = Console.ReadLine();



            while (input!="course start")
            {
                string[] commands = input.Split(':').ToArray();

                if (commands[0]=="Add")
                {
                    AddLessons(initialLessons,commands[1]);
                }
                else if (commands[0] == "Insert")
                {
                    InsertLessons(initialLessons, commands[1], int.Parse(commands[2]));
                }
                else if (commands[0] == "Remove")
                {
                    RemoveLessons(initialLessons,commands[1]);
                }
                else if (commands[0] == "Swap")
                {
                    SwapLessons(initialLessons, commands[1], commands[2]);
                }
                else if (commands[0] == "Exercise")
                {
                    AddExercise(initialLessons,commands[1]);
                }
                input = Console.ReadLine();
            }

            for (int i = 1; i <= initialLessons.Count; i++)
            {
                Console.WriteLine($"{i}.{initialLessons[i-1]}");
            }
        }

        private static void AddExercise(List<string> initialLessons, string exercise)
        {
            if (initialLessons.Contains(exercise))
            {
                int lessonIndex = initialLessons.IndexOf(exercise);
                if (lessonIndex!=initialLessons.Count-1 )
                {
                    if (initialLessons[lessonIndex + 1]!=exercise+"-Exercise")
                    {
                        initialLessons.Insert(lessonIndex + 1, exercise + "-Exercise");
                    }
                }
                else
                {
                    initialLessons.Add(exercise + "-Exercise");
                }
            }
            else
            {
                initialLessons.Add(exercise);
                initialLessons.Add(exercise + "-Exercise");
            }
        }

        private static void SwapLessons(List<string> initialLessons, string firstLesson, string secondLesson)
        {
            if (initialLessons.Contains(firstLesson)&& initialLessons.Contains(secondLesson))
            {
                int indexFirsLesson = initialLessons.IndexOf(firstLesson);
                int indexSecondLesson = initialLessons.IndexOf(secondLesson);

                string tmp = initialLessons[indexFirsLesson];
                initialLessons[indexFirsLesson] = initialLessons[indexSecondLesson];
                initialLessons[indexSecondLesson] = tmp;

                if (initialLessons.Contains(firstLesson+"-Exercise"))
                {
                    RemoveLessons(initialLessons, firstLesson + "-Exercise");
                    indexFirsLesson = initialLessons.IndexOf(firstLesson);

                    if (indexFirsLesson==initialLessons.Count-1)
                    {
                        AddLessons(initialLessons, firstLesson + "-Exercise");
                    }
                    else
                    {
                        InsertLessons(initialLessons, firstLesson + "-Exercise",indexFirsLesson+1);
                    }

                }
                if (initialLessons.Contains(secondLesson + "-Exercise"))
                {
                    RemoveLessons(initialLessons, secondLesson + "-Exercise");
                    indexSecondLesson = initialLessons.IndexOf(secondLesson);

                    if (indexSecondLesson == initialLessons.Count - 1)
                    {
                        AddLessons(initialLessons, secondLesson + "-Exercise");
                    }
                    else
                    {
                        InsertLessons(initialLessons, secondLesson + "-Exercise", indexSecondLesson + 1);
                    }

                }
            }
        }

        private static void RemoveLessons(List<string> initialLessons, string lesson)
        {
            if (initialLessons.Contains(lesson))
            {
                initialLessons.Remove(lesson);

                if (initialLessons.Contains(lesson+"-Exercise"))
                {
                    initialLessons.Remove(lesson + "-Exercise");
                }
            }
        }

        private static void InsertLessons(List<string> initialLessons, string lesson, int index)
        {
            if (!initialLessons.Contains(lesson)&& index>=0 && index<initialLessons.Count)
            {
                initialLessons.Insert(index, lesson);
            }
        }

        private static void AddLessons(List<string> initialLessons,string lesson)
        {
            if (!initialLessons.Contains(lesson))
            {
                initialLessons.Add(lesson);
            }
        }
    }
}
