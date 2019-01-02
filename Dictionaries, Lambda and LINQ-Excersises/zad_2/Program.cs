using System;
using System.Collections.Generic;
using System.Linq;
namespace zad_2
{
    class Program
    {
        static void Main()
        {
            var phonebook = new SortedDictionary<string, string>();
            while (true)
            {
                var input = Console.ReadLine().Split(' ').ToList();
                if (input[0] == "END" || input[0] == "End" || input[0] == "end")
                {
                    return;
                }
                else if (input[0] == "ListAll" || input[0] == "LISTALL" || input[0] == "listAll" || input[0] == "listall")
                {
                    foreach (var kvp in phonebook)
                    {
                        Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                    }
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
