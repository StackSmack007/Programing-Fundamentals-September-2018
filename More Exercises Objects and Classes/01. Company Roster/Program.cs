using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int numberOfInputs = int.Parse(Console.ReadLine());
        List<Department> result = new List<Department>();
        for (int i = 0; i < numberOfInputs; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            string employeeName = input[0];
            string departmentName = input[2];
            decimal employeeSalary = decimal.Parse(input[1]);
            int indexOfDepartment = result.FindIndex(x => x.Name == departmentName);
            if (indexOfDepartment == -1)
            {
                Department current = new Department
                {
                    Name = departmentName,
                    NameAndSalary = new Dictionary<string, decimal> { { employeeName, employeeSalary } }
                };
                result.Add(current);
            }
            else
            {
                result[indexOfDepartment].NameAndSalary[employeeName] = employeeSalary;
            }
        }
        result = result.OrderByDescending(x => x.NameAndSalary.Values.Sum() / x.NameAndSalary.Count()).ToList();
        Console.WriteLine("Highest Average Salary: {0}", result[0].Name);
        foreach (var kvp in result[0].NameAndSalary.OrderByDescending(x => x.Value))
        {
            Console.WriteLine($"{kvp.Key} {kvp.Value:F2}");
        }
    }
}
class Department
{
    public string Name { get; set; }
    public Dictionary<string, decimal> NameAndSalary { get; set; }
}