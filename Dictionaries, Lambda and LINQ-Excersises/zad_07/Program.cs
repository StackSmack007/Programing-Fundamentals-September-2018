using System;
using System.Collections.Generic;
using System.Linq;
namespace zad_07
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            char[] numbersList = input.Where(x => x <= 57 & x >= 48).ToArray();
            char[] nonNumbersList = input.Where(x => x > 57 || x < 48).ToArray();
            List<int> TakeList = new List<int>();
            List<int> SkipList = new List<int>();
            for (int i = 0; i < numbersList.Length; i++)
            {
                if (i % 2 == 0)
                {
                    TakeList.Add(numbersList[i] - 48);
                }
                else
                {
                    SkipList.Add(numbersList[i] - 48);
                }
            }
            List<char> result = new List<char>();
            int sumOfSkipped = 0;
            for (byte i = 0; i < TakeList.Count; i++)
            {
                List<char> temporary = nonNumbersList.Skip(sumOfSkipped).Take(TakeList[i]).ToList();
                result = result.Concat(temporary).ToList();
                sumOfSkipped += TakeList[i] + SkipList[i];
            }
            Console.WriteLine(string.Join("", result));
        }
    }
}