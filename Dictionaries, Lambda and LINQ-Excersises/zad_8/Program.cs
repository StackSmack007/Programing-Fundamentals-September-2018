using System;
using System.Collections.Generic;
using System.Linq;

namespace zad_8
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, List<string>> nameIPs = new Dictionary<string, List<string>>();
            Dictionary<string, int> nameTimeSpent = new Dictionary<string, int>();
            int inputCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputCount; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                // ip name time
                string name = input[1];
                string ip = input[0];
                int time = int.Parse(input[2]);
                if (!nameIPs.ContainsKey(name))
                {
                    nameIPs[name] = new List<string>();
                    nameIPs[name].Add(ip);

                    nameTimeSpent[name] = time;
                }
                else if (nameIPs[name].Contains(ip))
                {
                    nameTimeSpent[name] += time;
                }
                else
                {
                    nameIPs[name].Add(ip);
                    nameTimeSpent[name] += time;
                }
            }
            foreach (var kvp in nameTimeSpent.OrderBy(x => x.Key))
            {
                nameIPs[kvp.Key] = nameIPs[kvp.Key].OrderBy(x => x).Distinct().ToList();
                Console.WriteLine($"{kvp.Key}: {kvp.Value} [" + string.Join(", ", nameIPs[kvp.Key]) + "]");
            }
        }
    }
}
