using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> wagons = Console.ReadLine().Split(new char[] { ' ' }).Select(int.Parse).ToList();
        int wagonCappacity = int.Parse(Console.ReadLine());
        while (true)
        {
            string[] input = Console.ReadLine().Split(' ');
            if (input[0] == "end")
            {
                Console.WriteLine(string.Join(" ", wagons));
                return;
            }
            if (input[0] == "Add")
            {
                int newWagon = int.Parse(input[1]);
                wagons.Add(newWagon);
            }
            else
            {
                int newCommers = int.Parse(input[0]);
                for (int i = 0; i < wagons.Count; i++)
                {
                    if (wagons[i] + newCommers <= wagonCappacity)
                    {
                        wagons[i] += newCommers;
                        break;
                    }
                }
            }
        }
    }
}