using System;
using System.Collections.Generic;
using System.Linq;
namespace zad_01
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            var timeValue = new Dictionary<string, int>();
            for (int i = 0; i < input.Length; i++)
            {
                string[] time_i = input[i].Split(':').ToArray();
                int hours = int.Parse(time_i[0]);
                int minutes = int.Parse(time_i[1]);
                int value = hours * 60 + minutes;
                timeValue[input[i]] = value;
            }
            var result = new List<string>();
            foreach (var kvp in timeValue.OrderBy(x => x.Value))
            {
                result.Add(kvp.Key);
            }
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
