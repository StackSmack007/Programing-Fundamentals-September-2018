using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        List<string> sequence = Console.ReadLine().Split(' ').ToList();
        while (true)
        {
            string[] input = Console.ReadLine().Split(new char[] { '\t',' '},StringSplitOptions.RemoveEmptyEntries);
            if (input[0] == "3:1")
            {
                break;
            }
            string command = input[0];


            switch (command)
            {
                case "merge":
                    int startIndex = Math.Min(int.Parse(input[1]), int.Parse(input[2]));
                    int endIndex = Math.Max(int.Parse(input[1]), int.Parse(input[2]));
                    if (startIndex > sequence.Count - 1) startIndex = sequence.Count - 1;
                    if (startIndex < 0) startIndex = 0;
                    if (endIndex > sequence.Count - 1) endIndex = sequence.Count - 1;
                    if (endIndex < 0) endIndex = 0;
                    int range = endIndex - startIndex + 1;
                    string condensedString = "";
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        condensedString += sequence[i];
                    }
                    sequence.RemoveRange(startIndex, range);
                    sequence.Insert(startIndex, condensedString);
                    break;
                case "divide":
                    int indexOfElement = int.Parse(input[1]);
                    string element = sequence[indexOfElement];
                    int substrNumber = int.Parse(input[2]);
                    int substringLenghtMin = element.Length / substrNumber;
                    sequence.RemoveAt(indexOfElement);
                    string[] splits = new string[substrNumber].Select(x => x = "").ToArray();
                    for (int i = 0; i < substrNumber; i++)
                    {
                        for (int j = 0; j < substringLenghtMin; j++)
                        {
                            splits[i] += element[j];
                        }
                        element = element.Replace(splits[i], "");
                    }
                    if (element != "")
                    {
                        splits[splits.Length - 1] += element;
                    }
                    sequence.InsertRange(indexOfElement, splits);
                    break;
            }
        }
        Console.WriteLine(string.Join(" ", sequence));
    }
}
//18:35