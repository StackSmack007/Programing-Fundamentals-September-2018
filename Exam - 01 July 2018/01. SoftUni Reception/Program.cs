using System;
//10:05
class Program
{
    static void Main()
    {
        int employeesKPD = 0;
        for (int i = 0; i < 3; i++)
        {
            employeesKPD += int.Parse(Console.ReadLine());
        }
        int studentsCount = int.Parse(Console.ReadLine());
        int breaksCount = studentsCount / (3 * employeesKPD);
        if (breaksCount*3*employeesKPD == studentsCount)
        {
            breaksCount -= 1;
        }
        int result = (int)Math.Ceiling(1.0 * studentsCount / employeesKPD) + breaksCount;
        Console.WriteLine("Time needed: {0}h.",result);
    }
}
//10:40