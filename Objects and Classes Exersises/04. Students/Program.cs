using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int numberOfStudents = int.Parse(Console.ReadLine());
        Student[] studentsBank = new Student[numberOfStudents];
        for (int i = 0; i < numberOfStudents; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            Student current = new Student
            {
                FirstName = input[0],
                LastName = input[1],
                Grade = float.Parse(input[2])
            };
            studentsBank[i] = current;
        }
        studentsBank = studentsBank.OrderByDescending(x => x.Grade).ToArray();
        for (int i = 0; i < numberOfStudents; i++)
        {
            Console.WriteLine($"{studentsBank[i].FirstName} {studentsBank[i].LastName}: {studentsBank[i].Grade:F2}");
        }
    }
}
class Student
{
   public string FirstName { get; set; }
   public string LastName { get; set; }
   public float Grade { get; set; }

}