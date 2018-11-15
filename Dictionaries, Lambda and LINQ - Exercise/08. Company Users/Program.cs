using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, List<string>> companyEmployeesIds = new Dictionary<string, List<string>>();
        while (true)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
            if (input[0] == "End")
            {
                break;
            }
            string companyName = input[0];
            string EmployeeId = input[1];
            if (!companyEmployeesIds.ContainsKey(companyName))
            {
                companyEmployeesIds[companyName] = new List<string> { EmployeeId };
            }
            else if (!companyEmployeesIds[companyName].Contains(EmployeeId))
            {
                companyEmployeesIds[companyName].Add(EmployeeId);
            }
        }
        foreach (var kvp in companyEmployeesIds.OrderBy(x => x.Key))
        {
            Console.WriteLine(kvp.Key);
            foreach (string id in kvp.Value)
            {
                Console.WriteLine("-- " + id);
            }
        }
    }
}