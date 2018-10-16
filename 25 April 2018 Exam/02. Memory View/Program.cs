using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class Program
//10:28
{
    static void Main()
    {
        List<int> numberSequence = new List<int>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Visual Studio crash")
            {
                break;
            }
            int[] inputArray = input.Split(' ').Select(int.Parse).ToArray();
            numberSequence = numberSequence.Concat(inputArray).ToList();
        }
        List<string> result = new List<string>();
        for (int i = 0; i < numberSequence.Count - 5; i++)
        {
            string word = "";
            if (numberSequence[i] == 32656 &
            numberSequence[i + 1] == 19759 &
            numberSequence[i + 2] == 32763)
            {
                int symbolsCount = numberSequence[i + 4];
                for (int j = i + 6; j < Math.Min(i + 6 + symbolsCount,numberSequence.Count); j++)
                {
                    word += (char)numberSequence[j];
                }
                if (word.Length > 0)result.Add(word);
            }
        }
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
}
//11:15
//47 min