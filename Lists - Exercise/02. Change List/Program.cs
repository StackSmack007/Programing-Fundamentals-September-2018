using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> rowOfIntegers = Console.ReadLine().Split(new char[] { ' ' }).Select(int.Parse).ToList();
        while (true)
        {
            string[] input = Console.ReadLine().Split(' ');
            switch (input[0])
            {
                case "Delete":
                    rowOfIntegers.Remove(int.Parse(input[1]));
                    break;
                case "Insert":
                    rowOfIntegers.Insert(int.Parse(input[2]), int.Parse(input[1]));
                    break;
            }
            if (input[0]== "end")
            {
                Console.WriteLine(string.Join(" ",rowOfIntegers));
                return;
            }
        }
    }
}