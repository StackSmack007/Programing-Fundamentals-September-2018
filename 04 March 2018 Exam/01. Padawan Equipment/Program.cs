using System;

class Program
{
    static void Main()
    {
        decimal budget = decimal.Parse(Console.ReadLine());
        byte studentsCount = byte.Parse(Console.ReadLine());
        decimal priceOfLightSaber = decimal.Parse(Console.ReadLine());
        decimal priceOfRobe = decimal.Parse(Console.ReadLine());
        decimal priceOfbelt = decimal.Parse(Console.ReadLine());
        decimal cost = studentsCount * priceOfRobe + priceOfLightSaber * (int)Math.Ceiling(1.1 * studentsCount) + (studentsCount - studentsCount / 6) * priceOfbelt;
        if (cost <= budget)
        {
            Console.WriteLine($"The money is enough - it would cost {cost:F2}lv.");
        }
        else
        {
            Console.WriteLine("Ivan Cho will need {0:F2}lv more.", cost - budget);
        }
    }
}