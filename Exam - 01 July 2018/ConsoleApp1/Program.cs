using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> novList = new List<string> { "aba", "jaba", "baba" };
            novList.Insert(3, "sambo");
            
            Console.WriteLine(string.Join(", ",novList));
        }
    }
}
