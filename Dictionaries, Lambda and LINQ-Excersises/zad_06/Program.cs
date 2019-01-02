using System;
using System.Linq;
namespace zad_06
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ').Where(x => x.Length == 2).ToArray();
            for (int i = input.Length-1; i >=0 ; i--)
            {
                char[] result = input[i].ToCharArray();
                Array.Reverse(result);
                Console.Write(Convert.ToChar(Convert.ToInt32(new string(result), 16)));
            }
            Console.WriteLine();
        }
    }
}