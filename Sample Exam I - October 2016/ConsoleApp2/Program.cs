using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] textSymbols = Console.ReadLine().ToUpper().ToCharArray();
            List<char> symbols = new List<char>();
            foreach (char symbol in textSymbols)
            {
                if (!symbols.Contains(symbol))
                {
                    symbols.Add(symbol);
                }
            }
            Console.WriteLine(symbols.Count);
        }
    }
}