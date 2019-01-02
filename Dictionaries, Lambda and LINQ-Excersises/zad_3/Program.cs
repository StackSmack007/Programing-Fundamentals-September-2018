using System;
using System.Collections.Generic;

namespace zad_3
{
    class Program
    {
        static void Main()
        {
            var elements = new Dictionary<string, uint>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command.ToLower() == "stop")
                {
                    foreach (var kvp in elements)
                    {
                        Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                    }
                    return;
                }
                else if (!elements.ContainsKey(command))
                {
                    elements[command] = 0;
                }
                elements[command] += uint.Parse(Console.ReadLine());
            }
        }
    }
}
