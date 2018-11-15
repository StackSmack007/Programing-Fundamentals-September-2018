using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        List<int> numbersRow = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        int[] bombAndRange = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int bomb = bombAndRange[0];
        int range = bombAndRange[1];

        int indexOfbomb = numbersRow.IndexOf(bomb);
        while (indexOfbomb>-1)
        {
            int startIndex = Math.Max(0, indexOfbomb - range);
            int endIndex = Math.Min(numbersRow.Count - 1, indexOfbomb + range);
            int trueRange = 1+endIndex - startIndex;
            numbersRow.RemoveRange(startIndex, trueRange);
            indexOfbomb = numbersRow.IndexOf(bomb);
        }
                Console.WriteLine(numbersRow.Sum());
    }
}