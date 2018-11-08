using System;
using System.Collections.Generic;
using System.Linq;
//10:35
class Program
{
    static void Main()
    {
        List<int> data = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        while (true)
        {
            string[] inputArr = Console.ReadLine().Split(' ');
            if (inputArr[0] == "end")
            {
                goto print;
            }
            string command = inputArr[0];
            if (command == "reverse" || command == "sort")
            {
                int startIndex = int.Parse(inputArr[2]);
                int countOfElements = int.Parse(inputArr[4]);
                ReverseOrSortSubstring(data, startIndex, countOfElements, command);
            }
            if (command == "rollLeft" || command == "rollRight")
            {
                int turns = int.Parse(inputArr[1]);
                RollRightOrLeft(data, turns, command);
            }
        }

    print:
        Console.WriteLine("[" + string.Join(", ", data) + "]");
    }

    static void ReverseOrSortSubstring(List<int> list, int startIndex, int elementsToReverse, string action)
    {
        if (startIndex < 0 || startIndex + elementsToReverse > list.Count)
        {
            PrintError();
            return;
        }
        int[] temporarySubArray = list.Skip(startIndex).Take(elementsToReverse).ToArray();
        if (action == "reverse")
        {
            temporarySubArray = temporarySubArray.Reverse().ToArray();
        }
        else
        {
            temporarySubArray = temporarySubArray.OrderBy(x => x).ToArray();
        }
        list.RemoveRange(startIndex, elementsToReverse);
        list.InsertRange(startIndex, temporarySubArray);
    }

    static void RollRightOrLeft(List<int> list, int countOfTurns, string action)
    {
        if (action == "rollRight")
        {
            for (int i = 0; i < countOfTurns; i++)
            {
                int lastElement = list[list.Count - 1];
                for (int j = list.Count - 1; j > 0; j--)
                {
                    list[j] = list[j - 1];
                }
                list[0] = lastElement;
            }
        }
        else
        {
            for (int i = 0; i < countOfTurns; i++)
            {
                int firstElement = list[0];
                for (int j = 0; j < list.Count - 1; j++)
                {
                    list[j] = list[j + 1];
                }
                list[list.Count - 1] = firstElement;
            }
        }
    }

    static void PrintError()
    {
        Console.WriteLine("Invalid input parameters.");
    }
}
//11:16