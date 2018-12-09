using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> grainWathesList = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        //14:25
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Mort")
            {
                Console.WriteLine(string.Join(" ",grainWathesList));
                return;
            }
            string[] inputArr = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = inputArr[0];
            int value = int.Parse(inputArr[1]);
            bool isValueValidIndex = value < grainWathesList.Count & value >= 0;//optionals
            int replacement = command == "Replace" ? int.Parse(inputArr[2]) : -1;//optional
            switch (command)
            {
                case "Add":
                    grainWathesList.Add(value);
                    break;
                case "Remove":
                    int indexOfMatch = grainWathesList.IndexOf(value);
                    if (indexOfMatch == -1 & isValueValidIndex)
                    {
                        grainWathesList.RemoveAt(value);
                    }
                    else if (indexOfMatch >= 0)
                    {
                        grainWathesList.Remove(value);
                    }
                    break;
                case "Replace":
                    if (grainWathesList.Any(x => x == value))
                    {
                        grainWathesList[grainWathesList.IndexOf(value)] = replacement;
                    }
                    break;
                case "Increase":
                    int increese = 0;
                    if (grainWathesList.Any(x => x >= value))
                    {
                        int elementWhithMatchingValue = grainWathesList.First(x => x >= value);
                        increese = elementWhithMatchingValue;
                    }
                    else
                    {
                        increese = grainWathesList[grainWathesList.Count-1];
                    }
                    for (int i = 0; i < grainWathesList.Count; i++)
                    {
                        grainWathesList[i] += increese;
                    }
                    break;
                case "Collapse":
                    {
                        List<int> newList = new List<int>();
                        newList = grainWathesList.Where(x => x >= value).ToList();
                        grainWathesList = newList;
                        break;
                    }
            }
        }
    }
}
//15:25