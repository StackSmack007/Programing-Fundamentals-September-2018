using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, List<string>> courseStudents = new Dictionary<string, List<string>>();
        while (true)
        {
            string[] inputLine = Console.ReadLine().Split(':');
            string course = inputLine[0].Trim();
            if (course == "end")
            {
                break;
            }
            string student = inputLine[1].Trim();
            if (!courseStudents.ContainsKey(course))
            {
                courseStudents[course] = new List<string> { student };
            }
            else if (!courseStudents[course].Contains(student))
            {
                courseStudents[course].Add(student);
            }
        }
        foreach (var kvp in courseStudents.OrderByDescending(x=>x.Value.Count))
        {
            Console.WriteLine("{0}: {1}",kvp.Key,kvp.Value.Count);
            foreach (string student in kvp.Value.OrderBy(x=>x))
            {
                Console.WriteLine("-- {0}",student);
            }
        }
    }
}