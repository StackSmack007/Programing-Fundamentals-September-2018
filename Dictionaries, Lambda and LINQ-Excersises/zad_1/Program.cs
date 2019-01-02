using System;
using System.Collections.Generic;
using System.Linq;

namespace zad_1
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            while (true)
            {
                List<string> input = Console.ReadLine().Split(' ').ToList();
                if (input[0] == "END" || input[0] == "End" || input[0] == "end")
                {
                    return;
                }
                else if (input[0] == "A" || input[0] == "a")
                {
                    phonebook[input[1]] = input[2];
                }
                else if (input[0] == "S" || input[0] == "s")
                {
                    if (phonebook.ContainsKey(input[1]))
                    {
                        Console.WriteLine($"{input[1]} -> {phonebook[input[1]]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {input[1]} does not exist.");
                    }
                }
            }
        }
    }
}
