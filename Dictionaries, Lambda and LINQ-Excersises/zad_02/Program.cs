using System;
using System.Linq;

namespace zad_02
{
    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).Where(x => x % 2 == 0).ToArray();
            double sum = input.Sum();
            int count1 = input.Length - 1;
                        foreach (var item in input)
            {
                if (item > (sum - item) / count1)
                {
                    Console.Write(item + 1 + " ");
                }
                else
                {
                    Console.Write(item - 1 + " ");
                }
            }
            // input = input.Where(x => x > (sum - x) /count1).Select(x => x++).ToArray();
            //  Console.WriteLine(string.Join(" ", input));
        }
    }
}
