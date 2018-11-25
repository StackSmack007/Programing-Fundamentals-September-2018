using System;

//10:10
class Program
{
    static void Main()
    {
        decimal budget = decimal.Parse(Console.ReadLine());
        byte students = byte.Parse(Console.ReadLine());
        decimal priceFor1PackOfFlour = decimal.Parse(Console.ReadLine());
        decimal priceForSingleEgg = decimal.Parse(Console.ReadLine());
        decimal priceFor1Apron = decimal.Parse(Console.ReadLine());
        decimal totalCost = (priceFor1PackOfFlour)*(students-(int)(students/5)) + 10 * priceForSingleEgg*students + priceFor1Apron*(int)Math.Ceiling(students*1.2);
        if (totalCost <= budget)
        {
            Console.WriteLine($"Items purchased for {totalCost:F2}$.");
        }
        else
        {
            Console.WriteLine($"{(totalCost - budget):F2}$ more needed.");
        }
    }
}