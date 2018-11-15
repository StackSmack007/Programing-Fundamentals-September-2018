using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        List<int> listOfIntegers = Console.ReadLine().Split(new char[] {' ','\t' },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        while (true)
        {
            string[] command = Console.ReadLine().Split(' ');

            switch (command[0])
            {
                case "Add":
                    listOfIntegers.Add(int.Parse(command[1]));
                    break;

                case "Insert":
                    int index = int.Parse(command[2]);
                    if (index < 0 || index >= listOfIntegers.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    else
                    {
                        listOfIntegers.Insert(index, int.Parse(command[1]));
                        break;
                    }

                case "Remove":
                    int indexToRemove = int.Parse(command[1]);
                    if (indexToRemove < 0 || indexToRemove >= listOfIntegers.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    else
                    {
                        listOfIntegers.RemoveAt(indexToRemove);
                        break;
                    }

                case "Shift":
                    string destination = command[1];
                    int turns = int.Parse(command[2]);
                    if (destination == "right")
                    {
                        ShiftRight(listOfIntegers, turns);
                    }
                    else
                    {
                        ShiftLeft(listOfIntegers, turns);
                    }
                    break;

                case "End":
                    Console.WriteLine(string.Join(" ", listOfIntegers));
                    return;
            }
        }
    }
    static void ShiftRight(List<int> list, int numberOfTimes)
    {
        for (int i = 0; i < numberOfTimes; i++)
        {
            int lastElement = list[list.Count - 1];
            for (int j = list.Count-1; j > 0; j--)
            {
                list[j] = list[j - 1];
            }
            list[0] = lastElement;
        }
    }

    static void ShiftLeft(List<int> list, int numberOfTimes)
    {
        for (int i = 0; i < numberOfTimes; i++)
        {
            int firstElement = list[0];
            for (int j = 0; j < list.Count-1; j++)
            {
                list[j] = list[j + 1];
            }
            list[list.Count-1] = firstElement;
        }
    }
}