using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "3:1")
            {
                if (command[0] == "merge")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    List<string> mergedInput = Merge(input, startIndex, endIndex);
                    input = mergedInput;
                }
                else if (command[0] == "divide")
                {
                    int index = int.Parse(command[1]);
                    int partitions = int.Parse(command[2]);
                    if (partitions <= input[index].Count() && partitions > 0)
                    {
                        List<string> devidedInput = Divide(input, index, partitions);
                        input = devidedInput;
                    }

                }

                command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(" ", input));
        }

        private static List<string> Divide(List<string> input, int index, int partitions)
        {
            string textForDevide = "";


            textForDevide = input[index];
            int charCount = textForDevide.Length / partitions;
            input.RemoveAt(index);

            string subString = "";
            for (int i = 0; i < partitions - 1; i++)
            {

                for (int k = 0; k < charCount; k++)
                {
                    subString += textForDevide[0];
                    textForDevide = textForDevide.Remove(0, 1);
                }

                input.Insert(index, subString);
                subString = "";
                index++;
            }

            input.Insert(index, textForDevide);


            return input;
        }

        private static List<string> Merge(List<string> input, int startIndex, int endIndex)
        {
            string mergedText = "";

            if (startIndex < 0)
            {
                startIndex = 0;
            }

            if (endIndex >= input.Count)
            {
                endIndex = input.Count - 1;
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                mergedText += input[i];
            }


            if (mergedText != "")
            {
                input.RemoveRange(startIndex, endIndex - startIndex + 1);
                input.Insert(startIndex, mergedText);
            }


            return input;
        }
    }
}
