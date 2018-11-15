using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int studentsNumber = int.Parse(Console.ReadLine());
        Dictionary<string, List<float>> avGrades = new Dictionary<string, List<float>>();
        for (int i = 0; i < studentsNumber; i++)
        {
            string name = Console.ReadLine();
            float avGrade = float.Parse(Console.ReadLine());
            if (!avGrades.ContainsKey(name))
            {
                avGrades[name] = new List<float> { avGrade };
            }
            else
            {
                avGrades[name].Add(avGrade);
            }
        }
        foreach (var kvp in avGrades.Where(x=>x.Value.Sum()/x.Value.Count>=4.5).OrderByDescending(x => x.Value.Sum() / x.Value.Count))
        {
            Console.WriteLine($"{kvp.Key} -> {kvp.Value.Sum()/kvp.Value.Count:F2}");
        }
    }
}