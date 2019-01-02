using System;
using System.Collections.Generic;
namespace zad_4
{
    class Program
    {
        static void Main()
        {
            var emailBook = new Dictionary<string, string>();
            string[] inputArr = new string[2];
            while (true)
            {
                inputArr[0] = Console.ReadLine();
                if (inputArr[0].ToLower() == "stop")
                {
                    foreach (var kvp in emailBook)
                    {
                        Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                    }
                    return;
                }
                inputArr[1] = Console.ReadLine();
                if (!inputArr[1].ToLower().EndsWith("us") & !inputArr[1].ToLower().EndsWith("uk"))
                {
                    emailBook[inputArr[0]] = inputArr[1];
                }
            }
        }
    }
}
